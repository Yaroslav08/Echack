using System;
using System.ComponentModel.DataAnnotations;

namespace Ereceipt.Application.ViewModels.Comment
{
    public class CommentCreateModel : RequestModel
    {
        [Required(ErrorMessage = "Text is required"), MinLength(1, ErrorMessage = "Min length of login is 1 symbols"), MaxLength(500, ErrorMessage = "Max length of login is 500 symbols")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Receipt ID is required")]
        public Guid ReceiptId { get; set; }
    }
}
