using AutoMapper;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IReceiptRepository _ReceiptRepository;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper, IGroupMemberRepository groupMemberRepository, IReceiptRepository ReceiptRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _groupMemberRepository = groupMemberRepository;
            _ReceiptRepository = ReceiptRepository;
        }

        public async Task<bool> CanEditGroupAsync(Guid groupId, int userId)
        {
            var member = await _groupMemberRepository.FindAsync(d => d.UserId == userId && d.GroupId == groupId);
            if (member == null)
                return false;
            if (member.Title == "Creator")
                return true;
            return false;
        }

        public async Task<GroupResult> CreateGroupAsync(GroupCreateModel model)
        {
            var group = new Group
            {
                Name = model.Name,
                Desc = model.Desc,
                Color = model.Color,
                CreatedBy = model.UserId.ToString()
            };
            var groupToResult = await _groupRepository.CreateAsync(group);
            await _groupMemberRepository.CreateAsync(new GroupMember
            {
                GroupId = groupToResult.Id,
                UserId = model.UserId,
                Title = "Creator",
                CreatedBy = model.UserId.ToString()
            });
            return new GroupResult(_mapper.Map<GroupViewModel>(groupToResult));
        }

        public async Task<GroupResult> EditGroupAsync(GroupEditModel model)
        {
            if (!await CanEditGroupAsync(model.Id, model.UserId))
                return null;
            var group = await _groupRepository.FindAsTrackingAsync(d => d.Id == model.Id);
            if (group == null)
                return null;
            group.Name = model.Name;
            group.Desc = model.Desc;
            group.Color = model.Color;
            group.SetUpdateData(model);
            return new GroupResult(_mapper.Map<GroupViewModel>(await _groupRepository.UpdateAsync(group)));
        }

        public async Task<ListReceiptGroupResult> GetReceiptsByGroupIdAsync(Guid groupId, int skip = 0)
        {
            var receipts = _mapper.Map<List<ReceiptGroupViewModel>>(await _ReceiptRepository.GetReceiptsByGroupIdAsync(groupId, skip));
            receipts.ForEach(x =>
            {
                x.CommentsCount = _ReceiptRepository.GetCountCommentsByReceiptIdAsync(x.Id).Result;
            });
            return new ListReceiptGroupResult(receipts);
        }

        public async Task<GroupResult> GetGroupByIdAsync(Guid id)
        {
            return new GroupResult(_mapper.Map<GroupViewModel>(await _groupRepository.FindAsync(d => d.Id == id)));
        }

        public async Task<ListGroupResult> GetGroupsByUserIdAsync(int id)
        {
            return new ListGroupResult(_mapper.Map<List<GroupViewModel>>(await _groupRepository.GetGroupsByUserIdAsync(id)));
        }

        public async Task<GroupResult> RemoveGroupAsync(Guid id, int userId)
        {
            var group = await _groupRepository.FindAsTrackingAsync(d => d.Id == id);
            if (group == null)
                return null;
            if (!await CanEditGroupAsync(id, userId))
                return null;

            var groupMembersForRemove = await _groupMemberRepository.FindListAsTrackingAsync(d => d.GroupId == id);

            if(groupMembersForRemove!=null && groupMembersForRemove.Count > 0)
            {
                await _groupMemberRepository.RemoveRangeAsync(groupMembersForRemove);
            }



            var Receipts = await _ReceiptRepository.FindListAsTrackingAsync(d => d.GroupId == id);
            if(Receipts!=null || Receipts.Count>0) //ToDo (take out handler code)
            {
                Receipts.ForEach(d =>
                {
                    d.GroupId = null;
                    d.LastUpdatedAt = DateTime.UtcNow;
                    d.LastUpdatedBy = userId.ToString();
                    d.LastUpdatedFromIP = "::1";
                });
                await _ReceiptRepository.UpdateRangeAsync(Receipts);
            }
            return new GroupResult(_mapper.Map<GroupViewModel>(await _groupRepository.RemoveAsync(group)));
        }

        public async Task<GroupMemberResult> AddUserToGroupAsync(GroupMemberCreateModel model)
        {
            if (!await CanEditGroupAsync(model.GroupId, model.UserId))
                return null;

            var member = new GroupMember()
            {
                GroupId = model.GroupId,
                UserId = model.Id,
                CreatedBy = model.UserId.ToString(),
                Title = "Member"
            };

            var id = (await _groupMemberRepository.CreateAsync(member)).Id;
            return new GroupMemberResult(_mapper.Map<GroupMemberViewModel>(await _groupMemberRepository.GetWithDataById(id)));
        }

        public async Task<ListGroupMemberResult> GetGroupMembersAsync(Guid id)
        {
            return new ListGroupMemberResult(_mapper.Map<List<GroupMemberViewModel>>(await _groupMemberRepository.GetGroupMembersAsync(id)));
        }

        public async Task<GroupMemberResult> RemoveUserFromGroupAsync(GroupMemberCreateModel model)
        {
            var groupMember = await _groupMemberRepository.FindAsTrackingAsync(d => d.GroupId == model.GroupId && d.UserId == model.Id);
            if (groupMember == null)
                return new GroupMemberResult(null);
            if (!await CanEditGroupAsync(model.GroupId, model.UserId))
                return new GroupMemberResult(null);
            return new GroupMemberResult(_mapper.Map<GroupMemberViewModel>(await _groupMemberRepository.RemoveAsync(groupMember)));
        }

        public async Task<ListGroupResult> GetAllGroupsAsync(int skip)
        {
            return new ListGroupResult(_mapper.Map<List<GroupViewModel>>(await _groupRepository.GetAllAsync(20, skip)));
        }
    }
}