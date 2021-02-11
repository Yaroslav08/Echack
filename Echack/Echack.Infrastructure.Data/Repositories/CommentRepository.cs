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
    public class CommentRepository : CRUDRepository<Comment, long, EchackContext>, ICommentRepository
    {
        private EchackContext db;
        public CommentRepository(EchackContext _db) : base(_db)
        {
            db = _db;
        }

    }
}