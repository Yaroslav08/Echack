using Echack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository userRepository;


        public UnitOfWork(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }


        public IUserRepository UserRepository => userRepository;
    }
}