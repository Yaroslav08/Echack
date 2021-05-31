using System.ComponentModel.DataAnnotations;

namespace Ereceipt.Application.ViewModels.Comment
{
    public class CommentEditModel : CommentCreateModel
    {
        [Required(ErrorMessage = "ID is required")]
        public long Id { get; set; }
    }
}