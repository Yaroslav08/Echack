using Echack.Domain.Interfaces;
using Echack.Domain.Models;
using Echack.Infrastructure.Data.Context;
using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Infrastructure.Data.Repositories
{
    public class GroupMemberRepository : CRUDRepository<GroupMember, Guid, EchackContext>, IGroupMemberRepository
    {
        private EchackContext db;
        public GroupMemberRepository(EchackContext _db) : base(_db)
        {
            db = _db;
        }

    }
}