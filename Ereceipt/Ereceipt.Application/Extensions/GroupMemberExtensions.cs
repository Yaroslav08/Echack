using Ereceipt.Domain.Models;

namespace Ereceipt.Application.Extensions
{
    public static class GroupMemberExtensions
    {
        public static void SetCreatorPermissions(this GroupMember groupMember)
        {
            groupMember.IsCreator = true;
            groupMember.CanEditGroup = true;
            groupMember.CanAddMember = true;
            groupMember.CanRemoveMember = true;
            groupMember.CanControlBudget = true;
            groupMember.CanRemoveReceipt = true;
        }

        public static void SetUserPermissions(this GroupMember groupMember)
        {
            groupMember.IsCreator = false;
            groupMember.CanEditGroup = false;
            groupMember.CanAddMember = false;
            groupMember.CanRemoveMember = false;
            groupMember.CanControlBudget = false;
            groupMember.CanRemoveReceipt = false;
        }
    }
}
