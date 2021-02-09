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
    public class ChackRepository : CRUDRepository<Chack, Guid, EchackContext>, IChackRepository
    {
        private EchackContext db;
        public ChackRepository(EchackContext _db) : base(_db)
        {
            db = _db;
        }

    }
}