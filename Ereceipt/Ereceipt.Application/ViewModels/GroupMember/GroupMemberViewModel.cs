using Ereceipt.Application.ViewModels.Group;
using Ereceipt.Application.ViewModels.Receipt;
using System;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public GroupViewModel Group { get; set; }
        public UserReceiptViewModel User { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsCreator { get; set; }
        public bool CanEditGroup { get; set; }
        public bool CanAddMember { get; set; }
        public bool CanRemoveMember { get; set; }
        public bool CanControlBudget { get; set; }
        public bool CanRemoveReceipt { get; set; }
    }
}