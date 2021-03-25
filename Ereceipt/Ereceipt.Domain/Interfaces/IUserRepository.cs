using Ereceipt.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> SearchUsersAsync(string name, int afterId);
        Task<List<User>> GetAllAsync(int afterId);
    }
}