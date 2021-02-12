using Echack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Echack.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}