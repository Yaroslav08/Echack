using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using Ereceipt.Infrastructure.Data.Context;
using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Infrastructure.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {

    }
}