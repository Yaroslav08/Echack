using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public async Task<List<User>> GetAllAsync(int afterId)
        {
            if (afterId == 0)
                return await db.Users.AsNoTracking().Take(20).ToListAsync();
            return await db.Users.AsNoTracking().Where(d => d.Id > afterId).Take(20).ToListAsync();
        }

        public async Task<List<User>> SearchUsersAsync(string name, int afterId)
        {
            if (afterId == 0)
                return await db.Users.AsNoTracking().Where(d => d.Name.Contains(name)).Take(20).ToListAsync();
            return await db.Users.AsNoTracking().Where(d => d.Name.Contains(name) && d.Id > afterId).Take(20).ToListAsync();
        }
    }
}