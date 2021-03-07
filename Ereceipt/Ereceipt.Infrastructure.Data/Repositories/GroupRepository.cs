using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.Context;
using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ereceipt.Infrastructure.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
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