using Echack.Application.ViewModels.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Application.Interfaces
{
    public interface IGroupService
    {
        Task<GroupViewModel> GetGroupById(Guid id);
        Task<GroupViewModel> CreateGroup(GroupCreateViewModel model);
    }
}