using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.ViewModels.Chack
{
    public class UserChackViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
