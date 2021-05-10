using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.ViewModels.Comment
{
    public class CommentCreateModel : RequestModel
    {
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; }
        public Guid ReceiptId { get; set; }
    }
}
