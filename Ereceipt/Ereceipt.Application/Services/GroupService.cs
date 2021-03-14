using AutoMapper;
using Ereceipt.Application.Interfaces;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services
{
    public class GroupService : IGroupService
    {
        private IGroupRepository _groupRepository;
        private IGroupMemberRepository _groupMemberRepository;
        private IReceiptRepository _ReceiptRepository;
        private IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper, IGroupMemberRepository groupMemberRepository, IReceiptRepository ReceiptRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _groupMemberRepository = groupMemberRepository;
            _ReceiptRepository = ReceiptRepository;
        }

        public async Task<bool> CanEditGroup(Guid groupId, int userId)
        {
            var member = await _groupMemberRepository.FindAsync(d => d.UserId == userId && d.GroupId == groupId);
            if (member == null)
                return false;
            if (member.Title == "Creator")
                return true;
            return false;
        }

        public async Task<GroupViewModel> CreateGroup(GroupCreateViewModel model)
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
            return _mapper.Map<GroupViewModel>(groupToResult);
        }

        public async Task<GroupViewModel> EditGroup(GroupEditViewModel model)
        {
            if (!await CanEditGroup(model.Id, model.UserId))
                return null;
            var group = await _groupRepository.FindAsTrackingAsync(d => d.Id == model.Id);
            if (group == null)
                return null;
            group.Name = model.Name;
            group.Desc = model.Desc;
            group.Color = model.Color;
            group.UpdatedAt = DateTime.Now;
            group.UpdatedBy = model.UserId.ToString();
            return _mapper.Map<GroupViewModel>(await _groupRepository.UpdateAsync(group));
        }

        public async Task<List<ReceiptGroupViewModel>> GetReceiptsByGroupId(Guid groupId, int skip = 0)
        {
            return _mapper.Map<List<ReceiptGroupViewModel>>(await _ReceiptRepository.GetReceiptsByGroupIdAsync(groupId, skip));
        }

        public async Task<GroupViewModel> GetGroupById(Guid id)
        {
            return _mapper.Map<GroupViewModel>(await _groupRepository.FindAsync(d => d.Id == id));
        }

        public async Task<List<GroupViewModel>> GetGroupsByUserId(int id)
        {
            return _mapper.Map<List<GroupViewModel>>(await _groupRepository.GetGroupsByUserIdAsync(id));
        }

        public async Task<GroupViewModel> RemoveGroup(Guid id, int userId)
        {
            var group = await _groupRepository.FindAsTrackingAsync(d => d.Id == id);
            if (group == null)
                return null;
            if (!await CanEditGroup(id, userId))
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
                    d.UpdatedAt = DateTime.UtcNow;
                    d.UpdatedBy = userId.ToString();
                });
                await _ReceiptRepository.UpdateRangeAsync(Receipts);
            }
            return _mapper.Map<GroupViewModel>(await _groupRepository.RemoveAsync(group));
        }

        public async Task<GroupMemberViewModel> AddUserToGroup(GroupMemberCreateViewModel model)
        {
            if (!await CanEditGroup(model.GroupId, model.UserId))
                return null;

            var member = new GroupMember()
            {
                GroupId = model.GroupId,
                UserId = model.Id,
                CreatedBy = model.UserId.ToString(),
                Title = "Member"
            };

            var id = (await _groupMemberRepository.CreateAsync(member)).Id;
            return _mapper.Map<GroupMemberViewModel>(await _groupMemberRepository.GetWithDataById(id));
        }

        public async Task<List<GroupMemberViewModel>> GetGroupMembers(Guid id)
        {
            return _mapper.Map<List<GroupMemberViewModel>>(await _groupMemberRepository.GetGroupMembersAsync(id));
        }

        public async Task<GroupMemberViewModel> RemoveUserFromGroup(GroupMemberCreateViewModel model)
        {
            var groupMember = await _groupMemberRepository.FindAsTrackingAsync(d => d.GroupId == model.GroupId && d.UserId == model.Id);
            if (groupMember == null)
                return null;
            if (!await CanEditGroup(model.GroupId, model.UserId))
                return null;
            return _mapper.Map<GroupMemberViewModel>(await _groupMemberRepository.RemoveAsync(groupMember));
        }
    }
}