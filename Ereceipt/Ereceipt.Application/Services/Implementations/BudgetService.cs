using AutoMapper;
using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Budget;
using Ereceipt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Implementations
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        public BudgetService(IBudgetRepository budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
        }

        public async Task<ListBudgetResult> GetActiveBudgetsAsync(Guid groupId)
        {
            var budgets = await _budgetRepository.GetActiveBudgetsAsync(groupId);
            if (budgets is null || budgets.Count == 0)
                return new ListBudgetResult("Budgets not found");
            var budgetsToView = _mapper.Map<List<BudgetViewModel>>(budgets);
            return new ListBudgetResult(budgetsToView);
        }

        public async Task<ListBudgetResult> GetAllBudgetsAsync(Guid groupId)
        {
            var allBudgetsFromDb = await _budgetRepository.FindListAsync(x => x.GroupId == groupId);
            if (allBudgetsFromDb is null || allBudgetsFromDb.Count == 0)
                return new ListBudgetResult("Budgets not found");
            var budgetsToView = _mapper.Map<List<BudgetViewModel>>(allBudgetsFromDb);
            budgetsToView = budgetsToView.OrderByDescending(x => x.CreatedAt).ToList();
            return new ListBudgetResult(budgetsToView);
        }

        public async Task<BudgetResult> GetBudgetByIdAsync(int id, Guid groupId)
        {
            var budgetFromDb = await _budgetRepository.FindAsync(x => x.Id == id);
            if (budgetFromDb is null)
                return new BudgetResult("Budget by id not found");
            if (budgetFromDb.GroupId != groupId)
                return new BudgetResult("Can't get budget due to fake Group Id");
            var budgetToView = _mapper.Map<BudgetViewModel>(budgetFromDb);
            return new BudgetResult(budgetToView);
        }

        public async Task<ListBudgetResult> GetUnactiveBudgestAsync(Guid groupId)
        {
            var date = DateTime.UtcNow;
            var budgetsFromDB = await _budgetRepository.FindListAsync(x => x.GroupId == groupId && x.StartPeriod > date);
            if (budgetsFromDB is null || budgetsFromDB.Count == 0)
                return new ListBudgetResult("Budgets not found");
            var budgetsToView = _mapper.Map<List<BudgetViewModel>>(budgetsFromDB);
            budgetsToView = budgetsToView.OrderByDescending(x => x.CreatedAt).ToList();
            return new ListBudgetResult(budgetsToView);
        }
    }
}