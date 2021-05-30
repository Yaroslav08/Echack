using System.ComponentModel.DataAnnotations;

namespace Ereceipt.Application.ViewModels.Comment
{
    public class CommentEditModel : CommentCreateModel
    {
        [Required]
        public long Id { get; set; }
    }
}