using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.GroupMember;
using Ereceipt.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Interfaces
{
    public interface IGroupService
    {
        Task<GroupViewModel> GetGroupById(Guid id);
        Task<GroupViewModel> CreateGroup(GroupCreateViewModel model);
        Task<GroupMemberViewModel> AddUserToGroup(GroupMemberCreateViewModel model);
        Task<GroupMemberViewModel> RemoveUserFromGroup(GroupMemberCreateViewModel model);
        Task<GroupViewModel> EditGroup(GroupEditViewModel model);
        Task<GroupViewModel> RemoveGroup(Guid id, int userId);
        Task<List<ReceiptGroupViewModel>> GetReceiptsByGroupId(Guid groupId, int skip);
        Task<List<GroupMemberViewModel>> GetGroupMembers(Guid id);
        Task<List<GroupViewModel>> GetGroupsByUserId(int id);
        Task<bool> CanEditGroup(Guid groupId, int userId);
    }
}