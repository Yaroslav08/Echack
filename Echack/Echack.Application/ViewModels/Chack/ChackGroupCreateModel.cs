using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.ViewModels.Chack
{
    public class ChackGroupCreateModel : RequestModel
    {
        public Guid ChackId { get; set; }
        public Guid GroupId { get; set; }
    }
}