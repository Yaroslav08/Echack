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
        private IChackRepository chackRepository;
        private ICommentRepository commentRepository;
        private IGroupRepository groupRepository;
        private IGroupMemberRepository groupMemberRepository;
        private IUserRepository userRepository;

        public UnitOfWork(
            IChackRepository _chackRepository,
            ICommentRepository _commentRepository,
            IGroupRepository _groupRepository,
            IGroupMemberRepository _groupMemberRepository,
            IUserRepository _userRepository)
        {
            chackRepository = _chackRepository;
            commentRepository = _commentRepository;
            groupRepository = _groupRepository;
            groupMemberRepository = _groupMemberRepository;
            userRepository = _userRepository;
        }

        public IChackRepository ChackRepository => chackRepository;
        public ICommentRepository CommentRepository => commentRepository;
        public IGroupMemberRepository GroupMemberRepository => groupMemberRepository;
        public IGroupRepository GroupRepository => groupRepository;
        public IUserRepository UserRepository => userRepository;
    }
}