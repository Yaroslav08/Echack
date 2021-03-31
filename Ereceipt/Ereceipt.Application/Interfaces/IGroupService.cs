using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IGroupService
    {
        Task<GroupResult> GetGroupById(Guid id);
        Task<GroupResult> CreateGroup(GroupCreateViewModel model);
        Task<GroupMemberResult> AddUserToGroup(GroupMemberCreateViewModel model);
        Task<GroupMemberResult> RemoveUserFromGroup(GroupMemberCreateViewModel model);
        Task<GroupResult> EditGroup(GroupEditViewModel model);
        Task<GroupResult> RemoveGroup(Guid id, int userId);
        Task<ListReceiptGroupResult> GetReceiptsByGroupId(Guid groupId, int skip);
        Task<ListGroupMemberResult> GetGroupMembers(Guid id);
        Task<ListGroupResult> GetAllGroups(int skip);
        Task<ListGroupResult> GetGroupsByUserId(int id);
        Task<bool> CanEditGroup(Guid groupId, int userId);
    }
}