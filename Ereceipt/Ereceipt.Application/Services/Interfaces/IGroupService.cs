using Ereceipt.Application.Results.Groups;
using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using System;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Interfaces
{
    public interface IGroupService
    {
        Task<GroupResult> GetGroupByIdAsync(Guid id);
        Task<GroupResult> CreateGroupAsync(GroupCreateViewModel model);
        Task<GroupMemberResult> AddUserToGroupAsync(GroupMemberCreateViewModel model);
        Task<GroupMemberResult> RemoveUserFromGroupAsync(GroupMemberCreateViewModel model);
        Task<GroupResult> EditGroupAsync(GroupEditViewModel model);
        Task<GroupResult> RemoveGroupAsync(Guid id, int userId);
        Task<ListReceiptGroupResult> GetReceiptsByGroupIdAsync(Guid groupId, int skip);
        Task<ListGroupMemberResult> GetGroupMembersAsync(Guid id);
        Task<ListGroupResult> GetAllGroupsAsync(int skip);
        Task<ListGroupResult> GetGroupsByUserIdAsync(int id);
        Task<bool> CanEditGroupAsync(Guid groupId, int userId);
    }
}