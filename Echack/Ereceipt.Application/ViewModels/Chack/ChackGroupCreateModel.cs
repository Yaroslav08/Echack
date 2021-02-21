using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.Chack
{
    public class ChackGroupCreateModel : RequestModel
    {
        [Required]
        public Guid ChackId { get; set; }
        [Required]
        public Guid GroupId { get; set; }
    }
}