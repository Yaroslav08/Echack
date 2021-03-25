using Ereceipt.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<List<Group>> GetGroupsByUserIdAsync(int id);
    }
}