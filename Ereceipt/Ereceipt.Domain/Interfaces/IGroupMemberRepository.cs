using Ereceipt.Domain.Models;
using EFRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface IGroupMemberRepository : IRepository<GroupMember>
    {
        Task<GroupMember> GetWithDataById(Guid id);
        Task<List<GroupMember>> GetGroupMembersAsync(Guid id);
    }
}