using Echack.Domain.Models;
using EFRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Domain.Interfaces
{
    public interface IChackRepository : IRepository<Chack>
    {
        Task<List<Chack>> GetChacksByUserIdAsync(int ownerId, int skip);
        Task<List<Chack>> GetChacksByMounthAsync(int ownerId, int mounth);
        Task<List<Chack>> GetChacksByTimeAsync(int ownerId, DateTime from, DateTime to);
        Task<List<Chack>> GetChacksByShopNameAsync(int ownerId, string shopName, int afterId);
        Task<Chack> GetChackByIdAsync(Guid id);
        Task<List<Chack>> GetChacksByGroupIdAsync(Guid groupId, Guid afterId);
    }
}