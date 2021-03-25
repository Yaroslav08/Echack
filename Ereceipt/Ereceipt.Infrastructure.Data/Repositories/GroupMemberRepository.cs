using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Infrastructure.Data.Repositories
{
    public class GroupMemberRepository : Repository<GroupMember>, IGroupMemberRepository
    {
        public async Task<List<GroupMember>> GetGroupMembersAsync(Guid id)
        {
            return await db.GroupMembers
                .AsNoTracking()
                .Include(d => d.User)
                .Where(d => d.GroupId == id)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();
        }

        public async Task<GroupMember> GetWithDataById(Guid id)
        {
            return await db.GroupMembers
                .AsNoTracking()
                .Include(d => d.User)
                .Include(d => d.Group)
                .SingleOrDefaultAsync(d => d.Id == id);
        }
    }
}