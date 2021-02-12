using Echack.Domain.Interfaces;
using Echack.Domain.Models;
using Echack.Infrastructure.Data.Context;
using EFRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Echack.Infrastructure.Data.Repositories
{
    public class UserRepository : CRUDRepository<User, int, EchackContext>, IUserRepository
    {
        private EchackContext db;
        public UserRepository(EchackContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<User>> SearchUsersAsync(string name, int afterId)
        {
            if (afterId == 0)
                return await db.Users.AsNoTracking().Where(d => d.Name.Contains(name)).Take(20).ToListAsync();
            return await db.Users.AsNoTracking().Where(d => d.Name.Contains(name) && d.Id > afterId).Take(20).ToListAsync();
        }
    }
}