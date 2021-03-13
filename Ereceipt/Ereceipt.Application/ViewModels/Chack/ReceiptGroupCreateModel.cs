using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.Receipt
{
    public class ReceiptGroupCreateModel : RequestModel
    {
        [Required]
        public Guid ReceiptId { get; set; }
        [Required]
        public Guid GroupId { get; set; }
    }
}