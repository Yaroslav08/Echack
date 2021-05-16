using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Ereceipt.Infrastructure.Data.Repositories.EF
{
    public class EFGroupRepository : EFRepository<Group>, IGroupRepository
    {
        public EFGroupRepository(EreceiptContext db) : base(db) { }


        public async Task<List<Group>> GetGroupsByUserIdAsync(int id)
        {
            return await db.GroupMembers
                .AsNoTracking()
                .Where(d => d.UserId == id)
                .Select(d => d.Group)
                .ToListAsync();
        }
    }
}