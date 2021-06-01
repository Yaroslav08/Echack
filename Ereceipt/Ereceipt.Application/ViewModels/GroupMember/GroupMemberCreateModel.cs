using System;
using System.ComponentModel.DataAnnotations;
namespace Ereceipt.Application.ViewModels.GroupMember
{
    public class GroupMemberCreateModel : RequestModel
    {
        [Required(ErrorMessage = "Group ID is required")]
        public Guid GroupId { get; set; }
        [Required(ErrorMessage = "ID is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MinLength(1, ErrorMessage = "Min length of title is 1 symbols")]
        [MaxLength(100, ErrorMessage = "Max length of title is 100 symbols")]
        public string Title { get; set; }
        public bool IsCreator { get; set; }
        public bool CanEditGroup { get; set; }
        public bool CanAddMember { get; set; }
        public bool CanRemoveMember { get; set; }
        public bool CanControlBudget { get; set; }
        public bool CanRemoveReceipt { get; set; }
    }
}