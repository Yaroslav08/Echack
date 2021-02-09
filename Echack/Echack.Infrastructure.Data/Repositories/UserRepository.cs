using Echack.Domain.Interfaces;
using Echack.Domain.Models;
using Echack.Infrastructure.Data.Context;
using EFRepository;
namespace Echack.Infrastructure.Data.Repositories
{
    public class UserRepository : CRUDRepository<User, int, EchackContext>, IUserRepository
    {
        private EchackContext db;
        public UserRepository(EchackContext _db) : base(_db)
        {
            db = _db;
        }

    }
}