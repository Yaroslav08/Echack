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
        Task<GroupResult> CreateGroupAsync(GroupCreateModel model);
        Task<GroupMemberResult> AddUserToGroupAsync(GroupMemberCreateModel model);
        Task<GroupMemberResult> RemoveUserFromGroupAsync(GroupMemberCreateModel model);
        Task<GroupResult> EditGroupAsync(GroupEditModel model);
        Task<GroupMemberResult> EditPermissionsInUserAsync(GroupMemberEditModel model);
        Task<GroupResult> RemoveGroupAsync(Guid id, int userId);
        Task<ListReceiptGroupResult> GetReceiptsByGroupIdAsync(Guid groupId, int skip);
        Task<ListGroupMemberResult> GetGroupMembersAsync(Guid id);
        Task<ListGroupResult> GetAllGroupsAsync(int skip);
        Task<ListGroupResult> GetGroupsByUserIdAsync(int id);
    }
}