using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ereceipt.Domain.Interfaces
{
    public interface IGroupMemberRepository : IRepository<GroupMember>
    {
        Task<GroupMember> GetWithDataById(Guid id);
        Task<List<GroupMember>> GetGroupMembersAsync(Guid id);
        Task<GroupMember> GetGroupMemberByIdAsync(Guid groupId, int userId);
    }
}