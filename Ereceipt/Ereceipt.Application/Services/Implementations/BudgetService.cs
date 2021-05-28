using AutoMapper;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Budget;
using Ereceipt.Application.ViewModels.Currency;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Ereceipt.Application.Services.Implementations
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IJsonConverter _jsonConverter;
        private readonly IMapper _mapper;
        public BudgetService(IBudgetRepository budgetRepository, IMapper mapper, ICurrencyRepository currencyRepository, IJsonConverter jsonConverter)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _currencyRepository = currencyRepository;
            _jsonConverter = jsonConverter;
        }

        public Task<BudgetResult> AddReceiptToBudgetAsync(BudgetReceiptCreateModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<BudgetResult> CreateBudgetAsync(BudgetCreateModel model)
        {
            var currencyById = _mapper.Map<CurrencyViewModel>(await _currencyRepository.FindAsync(x => x.Id == model.CurrencyId));
            if (currencyById is null)
                return new BudgetResult("Currency by ID not found");
            var budgetToDb = _mapper.Map<Budget>(model);
            budgetToDb.Currency = _jsonConverter.GetStringAsJson(currencyById);
            budgetToDb.CreatedAt = DateTime.UtcNow;
            budgetToDb.CreatedBy = model.UserId.ToString();
            var budgetFromDb = await _budgetRepository.CreateAsync(budgetToDb);
            return new BudgetResult(_mapper.Map<BudgetViewModel>(budgetFromDb));
        }

        public async Task<BudgetResult> EditBudgetAsync(BudgetEditModel budgetModel)
        {
            var budgetForEdit = await _budgetRepository.FindAsTrackingAsync(x => x.Id == budgetModel.Id);
            if (budgetForEdit is null)
                return new BudgetResult("Budget for edit not found");

            //ToDo: check can current user edit budget

            budgetForEdit.Name = budgetModel.Name;
            budgetForEdit.Balance = budgetModel.Balance;
            budgetForEdit.Description = budgetModel.Description;
            budgetForEdit.EndPeriod = budgetModel.EndPeriod;
            budgetForEdit.StartPeriod = budgetModel.StartPeriod;
            if (budgetModel.CurrencyId != null)
            {
                var newCurrency = _mapper.Map<CurrencyViewModel>(await _currencyRepository.FindAsync(x => x.Id == budgetModel.CurrencyId));
                if (newCurrency is null)
                    return new BudgetResult("Currency with this id not found");
                budgetForEdit.Currency = _jsonConverter.GetStringAsJson(newCurrency);
            }
            budgetForEdit.SetUpdateData(budgetModel);
            var updatedBudget = _mapper.Map<BudgetViewModel>(await _budgetRepository.UpdateAsync(budgetForEdit));
            return new BudgetResult(updatedBudget);
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

        public async Task<ListReceiptResult> GetReceiptsByBudgetAsync(Guid groupId, long budgetId, int skip)
        {
            var budgetToCheck = await _budgetRepository.FindAsync(x => x.Id == budgetId);
            if (budgetToCheck is null)
                return new ListReceiptResult("Budget not found");
            if (budgetToCheck.GroupId != groupId)
                return new ListReceiptResult("The current budget is not in this group");
            var receiptsToView = await _budgetRepository.GetReceiptsByBudgetIdAsync(budgetId, skip);
            if (receiptsToView is null || receiptsToView.Count == 0)
                return new ListReceiptResult("Receipts not found");
            return new ListReceiptResult(_mapper.Map<List<ReceiptViewModel>>(receiptsToView));
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

        public Task<BudgetResult> RemoveReceiptFromBudgetAsync(BudgetReceiptCreateModel model)
        {
            throw new NotImplementedException();
        }
    }
}