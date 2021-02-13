using Echack.Domain.Models;
using EFRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> SearchUsersAsync(string name, int afterId);
        Task<List<User>> GetAllAsync(int afterId);
    }
}