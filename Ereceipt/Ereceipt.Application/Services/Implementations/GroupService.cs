using AutoMapper;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using Ereceipt.Application.Wrappers;
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
        private readonly IReceiptRepository _receiptRepository;
        private readonly IMapper _mapper;
        private readonly IGroupMemberCheck _groupMemberCheck;
        private readonly IEntityService _entityService;
        public GroupService(IGroupRepository groupRepository, IMapper mapper, IGroupMemberRepository groupMemberRepository, IReceiptRepository ReceiptRepository, IGroupMemberCheck groupMemberCheck, IEntityService entityService)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _groupMemberRepository = groupMemberRepository;
            _receiptRepository = ReceiptRepository;
            _groupMemberCheck = groupMemberCheck;
            _entityService = entityService;
        }

        public async Task<GroupResult> CreateGroupAsync(GroupCreateModel model)
        {
            var groupToCreate = new Group
            {
                Name = model.Name,
                Desc = model.Desc,
                CreatedBy = model.UserId.ToString()
            };
            if (string.IsNullOrEmpty(model.Color))
                groupToCreate.Color = "#1c64d9";
            else
            {
                if (!model.Color.IsHexColor())
                    return new GroupResult("This color isn't HEX");
                groupToCreate.Color = model.Color;
            }
            groupToCreate.SetInitData(model);
            var groupToResult = await _groupRepository.CreateAsync(groupToCreate);
            var creatorMember = new GroupMember
            {
                GroupId = groupToResult.Id,
                UserId = model.UserId,
                Title = "Creator",
                CreatedBy = model.UserId.ToString()
            };
            creatorMember.SetInitData(model);
            creatorMember.SetCreatorPermissions();
            await _groupMemberRepository.CreateAsync(creatorMember);
            return new GroupResult(_mapper.Map<GroupViewModel>(groupToResult));
        }

        public async Task<GroupResult> EditGroupAsync(GroupEditModel model)
        {
            var groupMember = await _groupMemberRepository.GetGroupMemberByIdAsync(model.Id,model.UserId);
            if (groupMember is null)
                return new GroupResult("Your not a member of this group");
            if (!_groupMemberCheck.CanMakeAction(groupMember, GroupActionType.CanEditGroup))
                return new GroupResult("Access denited");
            var groupToEdit = await _groupRepository.FindAsTrackingAsync(d => d.Id == model.Id);
            if (groupToEdit == null)
                return new GroupResult("Group for edit not found");
            groupToEdit.Name = model.Name;
            groupToEdit.Desc = model.Desc;
            if (!string.IsNullOrEmpty(model.Color))
            {
                if (!model.Color.IsHexColor())
                    return new GroupResult("This color isn't HEX");
                groupToEdit.Color = model.Color;
            }
            groupToEdit.SetUpdateData(model);
            return new GroupResult(_mapper.Map<GroupViewModel>(await _groupRepository.UpdateAsync(groupToEdit)));
        }

        public async Task<ListReceiptGroupResult> GetReceiptsByGroupIdAsync(Guid groupId, int skip = 0)
        {
            var receipts = _mapper.Map<List<ReceiptGroupViewModel>>(await _receiptRepository.GetReceiptsByGroupIdAsync(groupId, skip));
            receipts.ForEach(x =>
            {
                x.CommentsCount = _receiptRepository.GetCountCommentsByReceiptIdAsync(x.Id).Result;
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
                return new GroupResult("Group for delete not found");

            var groupMember = await _groupMemberRepository.GetGroupMemberByIdAsync(id, userId);
            if (!groupMember.IsCreator)
                return new GroupResult("Access denited");

            var groupMembersForRemove = await _groupMemberRepository.FindListAsTrackingAsync(d => d.GroupId == id);

            if (groupMembersForRemove != null && groupMembersForRemove.Count > 0)
            {
                await _groupMemberRepository.RemoveRangeAsync(groupMembersForRemove);
            }

            var receiptsForUpdate = await _receiptRepository.FindListAsTrackingAsync(d => d.GroupId == id);
            if (receiptsForUpdate != null && receiptsForUpdate.Count > 0) //ToDo (take out handler code)
            {
                receiptsForUpdate.ForEach(d =>
                {
                    d.GroupId = null;
                    d.LastUpdatedAt = DateTime.UtcNow;
                    d.LastUpdatedBy = userId.ToString();
                    d.LastUpdatedFromIP = "::1";
                });
                await _receiptRepository.UpdateRangeAsync(receiptsForUpdate);
            }
            return new GroupResult(_mapper.Map<GroupViewModel>(await _groupRepository.RemoveAsync(group)));
        }

        public async Task<GroupMemberResult> AddUserToGroupAsync(GroupMemberCreateModel model)
        {
            var groupMember = await _groupMemberRepository.GetGroupMemberByIdAsync(model.GroupId, model.UserId);
            if (!_groupMemberCheck.CanMakeAction(groupMember, GroupActionType.CanAddMember))
                return new GroupMemberResult("Access denited");
            if (!await _entityService.IsExistAsync<User>(x => x.Id == model.Id))
                return new GroupMemberResult("User for add not found");
            if (await _entityService.IsExistAsync<GroupMember>(x => x.GroupId == model.GroupId && x.UserId == model.Id))
                return new GroupMemberResult("This user is already a member of this group");
            var newMember = new GroupMember()
            {
                GroupId = model.GroupId,
                UserId = model.Id,
                CreatedBy = model.UserId.ToString(),
                Title = model.Title
            };
            newMember.SetInitData(model);
            newMember.SetUserPermissions();
            var id = (await _groupMemberRepository.CreateAsync(newMember)).Id;
            return new GroupMemberResult(_mapper.Map<GroupMemberViewModel>(await _groupMemberRepository.GetWithDataById(id)));
        }

        public async Task<ListGroupMemberResult> GetGroupMembersAsync(Guid id)
        {
            return new ListGroupMemberResult(_mapper.Map<List<GroupMemberViewModel>>(await _groupMemberRepository.GetGroupMembersAsync(id)));
        }

        public async Task<GroupMemberResult> RemoveUserFromGroupAsync(GroupMemberRemoveModel model)
        {
            var groupMember = await _groupMemberRepository.FindAsync(x => x.Id == model.GroupMemberId);
            if (groupMember == null)
                return new GroupMemberResult("Member not found");
            var currentMember = await _groupMemberRepository.GetGroupMemberByIdAsync(groupMember.GroupId, model.UserId);
            if (!_groupMemberCheck.CanMakeAction(currentMember, GroupActionType.CanRemoveMember))
                return new GroupMemberResult("Access denited");
            return new GroupMemberResult(_mapper.Map<GroupMemberViewModel>(await _groupMemberRepository.RemoveAsync(groupMember)));
        }

        public async Task<ListGroupResult> GetAllGroupsAsync(int skip)
        {
            return new ListGroupResult(_mapper.Map<List<GroupViewModel>>(await _groupRepository.GetAllAsync(20, skip)));
        }

        public async Task<GroupMemberResult> EditPermissionsInUserAsync(GroupMemberEditModel model)
        {
            var memberForEdit = await _groupMemberRepository.FindAsync(x => x.Id == model.Id);
            if (memberForEdit == null)
                return new GroupMemberResult("Member not found");

            var currentMember = await _groupMemberRepository.GetGroupMemberByIdAsync(memberForEdit.GroupId, model.UserId);
            if (!_groupMemberCheck.CanMakeAction(currentMember, GroupActionType.CanEditPermissions))
                return new GroupMemberResult("Access denited");

            memberForEdit.Title = model.Title;
            memberForEdit.CanAddMember = model.CanAddMember;
            memberForEdit.CanControlBudget = model.CanControlBudget;
            memberForEdit.CanEditGroup = model.CanEditGroup;
            memberForEdit.CanRemoveMember = model.CanRemoveMember;
            memberForEdit.CanRemoveReceipt = model.CanRemoveReceipt;
            memberForEdit.SetUpdateData(model);
            return new GroupMemberResult(_mapper.Map<GroupMemberViewModel>(await _groupMemberRepository.UpdateAsync(memberForEdit)));
        }
    }
}