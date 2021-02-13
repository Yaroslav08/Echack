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
        IChackRepository ChackRepository { get; }
        ICommentRepository CommentRepository { get; }
        IGroupRepository GroupRepository { get; }
        IGroupMemberRepository GroupMemberRepository { get; }
    }
}