using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Wrappers
{
    public enum GroupActionType
    {
        CanEditGroup,
        CanAddMember,
        CanRemoveMember,
        CanControlBudget,
        CanRemoveReceipt
    }

    public interface IGroupMemberCheck
    {
        bool CanMakeAction(GroupMember groupMember, GroupActionType groupAction = GroupActionType.CanEditGroup);
    }

    public class GroupMemberCheck : IGroupMemberCheck
    {
        public bool CanMakeAction(GroupMember groupMember, GroupActionType groupAction = GroupActionType.CanEditGroup)
        {
            if (groupMember == null)
                return false;
            return groupAction switch
            {
                GroupActionType.CanEditGroup => groupMember.CanEditGroup,
                GroupActionType.CanAddMember => groupMember.CanAddMember,
                GroupActionType.CanRemoveMember => groupMember.CanRemoveMember,
                GroupActionType.CanControlBudget => groupMember.CanControlBudget,
                GroupActionType.CanRemoveReceipt => groupMember.CanRemoveReceipt,
                _ => false
            };
        }
    }
}