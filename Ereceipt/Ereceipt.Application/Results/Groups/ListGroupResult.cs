using Ereceipt.Application.ViewModels.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.Results.Groups
{
    public class ListGroupResult : Result<List<GroupViewModel>>
    {
        public ListGroupResult(List<GroupViewModel> groups) : base(groups) { }
    }
}