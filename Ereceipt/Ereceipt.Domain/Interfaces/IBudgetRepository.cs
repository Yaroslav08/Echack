﻿using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ereceipt.Domain.Interfaces
{
    public interface IBudgetRepository : IRepository<Budget>
    {
        Task<List<Budget>> GetActiveBudgetsAsync(Guid id);
    }
}