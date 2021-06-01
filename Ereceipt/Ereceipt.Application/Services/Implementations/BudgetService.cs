using AutoMapper;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.Budget;
using Ereceipt.Application.ViewModels.Currency;
using Ereceipt.Application.ViewModels.Receipt;
using Ereceipt.Application.Wrappers;
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
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IReceiptRepository _receiptRepository;
        private readonly IJsonConverter _jsonConverter;
        private readonly IGroupMemberCheck _groupMemberCheck;
        private readonly IMapper _mapper;
        public BudgetService(IBudgetRepository budgetRepository, IMapper mapper, ICurrencyRepository currencyRepository, IJsonConverter jsonConverter, IReceiptRepository receiptRepository, IGroupMemberRepository groupMemberRepository, IGroupMemberCheck groupMemberCheck)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
            _currencyRepository = currencyRepository;
            _jsonConverter = jsonConverter;
            _receiptRepository = receiptRepository;
            _groupMemberRepository = groupMemberRepository;
            _groupMemberCheck = groupMemberCheck;
        }

        public async Task<BudgetResult> AddReceiptToBudgetAsync(BudgetReceiptCreateModel model)
        {
            var receiptToAdd = await _receiptRepository.FindAsTrackingAsync(x => x.Id == model.ReceiptId);
            if (receiptToAdd is null)
                return new BudgetResult("Receipt not found");
            if (receiptToAdd.UserId != model.UserId)
                return new BudgetResult("Access denited");
            if (receiptToAdd.BudgetId == model.BudgetId)
                return new BudgetResult("Receipt already reference with this budget");
            if (receiptToAdd.BudgetId != null)
                return new BudgetResult("Receipt already reference with other budget");
            var budgetForAdd = await _budgetRepository.FindAsTrackingAsync(x => x.Id == model.BudgetId);
            if (budgetForAdd is null)
                return new BudgetResult("Budget not found");

            var receiptCurrency = _jsonConverter.GetModelFromJson<Currency>(receiptToAdd.Currency);
            var budgetCurrency = _jsonConverter.GetModelFromJson<Currency>(budgetForAdd.Currency);
            if (receiptCurrency.ISOFormat != budgetCurrency.ISOFormat)
                return new BudgetResult("Unable to add receipt due to different currency");

            if (budgetForAdd.Balance < receiptToAdd.TotalPrice)
                return new BudgetResult("The balance in this budget is crowded");
            receiptToAdd.BudgetId = budgetForAdd.Id;
            await _receiptRepository.UpdateAsync(receiptToAdd);
            budgetForAdd.Balance = budgetForAdd.Balance - receiptToAdd.TotalPrice;
            var updatedBudget = await _budgetRepository.UpdateAsync(budgetForAdd);
            return new BudgetResult(_mapper.Map<BudgetViewModel>(updatedBudget));
        }

        public async Task<BudgetResult> CreateBudgetAsync(BudgetCreateModel model)
        {
            if (model.EndPeriod.Subtract(model.StartPeriod) < TimeSpan.FromDays(1))
                return new BudgetResult("The difference between the start date and the end date must be more than one day");
            if (model.Balance <= 0)
                return new BudgetResult("Balance must be more than 0");
            var member = await _groupMemberRepository.GetGroupMemberByIdAsync(model.GroupId, model.UserId);
            if (member is null)
                return new BudgetResult("Your aren't a member of group from this budget");
            if (!_groupMemberCheck.CanMakeAction(member, GroupActionType.CanControlBudget))
                return new BudgetResult("Access denited");
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
            if (budgetModel.EndPeriod.Subtract(budgetModel.StartPeriod) < TimeSpan.FromDays(1))
                return new BudgetResult("The difference between the start date and the end date must be more than one day");
            if (budgetModel.Balance <= 0)
                return new BudgetResult("Balance must be more than 0");
            var budgetForEdit = await _budgetRepository.FindAsTrackingAsync(x => x.Id == budgetModel.Id);
            if (budgetForEdit is null)
                return new BudgetResult("Budget for edit not found");
            var member = await _groupMemberRepository.GetGroupMemberByIdAsync(budgetForEdit.GroupId, budgetModel.UserId);
            if (member is null)
                return new BudgetResult("Your aren't a member of group from this budget");
            if (!_groupMemberCheck.CanMakeAction(member, GroupActionType.CanControlBudget))
                return new BudgetResult("Access denited");
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

        public async Task<ListBudgetResult> GetActiveBudgetsAsync(Guid groupId)
        {
            var budgets = await _budgetRepository.GetActiveBudgetsAsync(groupId);
            if (budgets is null || budgets.Count == 0)
                return new ListBudgetResult("Budgets not found");
            var budgetsToView = _mapper.Map<List<BudgetViewModel>>(budgets);
            return new ListBudgetResult(budgetsToView);
        }

        public async Task<ListBudgetResult> GetUnactiveBudgestAsync(Guid groupId)
        {
            var budgets = await _budgetRepository.GetUnactiveBudgetsAsync(groupId);
            if (budgets is null || budgets.Count == 0)
                return new ListBudgetResult("Budgets not found");
            var budgetsToView = _mapper.Map<List<BudgetViewModel>>(budgets);
            return new ListBudgetResult(budgetsToView);
        }

        public async Task<BudgetResult> RemoveReceiptFromBudgetAsync(BudgetReceiptCreateModel model)
        {
            var receiptToEdit = await _receiptRepository.FindAsTrackingAsync(x => x.Id == model.ReceiptId);
            if (receiptToEdit is null)
                return new BudgetResult("Receipt not found");
            if (receiptToEdit.BudgetId is null)
                return new BudgetResult("It is impossible to untie the receipt");
            if (receiptToEdit.UserId != model.UserId)
                return new BudgetResult("Access denited");
            if (receiptToEdit.BudgetId != model.BudgetId)
                return new BudgetResult("Receipt don't reference with budget");
            var budgetForEdit = await _budgetRepository.FindAsTrackingAsync(x => x.Id == model.BudgetId);
            if (budgetForEdit is null)
                return new BudgetResult("Budget not found");
            var member = await _groupMemberRepository.GetGroupMemberByIdAsync(budgetForEdit.GroupId, model.UserId);
            if (member is null)
                return new BudgetResult("Your aren't a member of group from this budget");
            if (!_groupMemberCheck.CanMakeAction(member, GroupActionType.CanControlBudget))
                return new BudgetResult("Access denited");

            receiptToEdit.BudgetId = null;
            await _receiptRepository.UpdateAsync(receiptToEdit);
            budgetForEdit.Balance = budgetForEdit.Balance + receiptToEdit.TotalPrice;
            var budgetToView = await _budgetRepository.UpdateAsync(budgetForEdit);
            return new BudgetResult(_mapper.Map<BudgetViewModel>(budgetToView));
        }

        public async Task<BudgetResult> RemoveBudgetAsync(BudgetRemoveModel model)
        {
            var budgetForRemove = await _budgetRepository.FindAsTrackingAsync(x => x.Id == model.BudgetId);
            if (budgetForRemove is null)
                return new BudgetResult("Budget for remove not found");
            var member = await _groupMemberRepository.GetGroupMemberByIdAsync(budgetForRemove.GroupId, model.UserId);
            if (member is null)
                return new BudgetResult("Your aren't a member of group from this budget");
            if (!_groupMemberCheck.CanMakeAction(member, GroupActionType.CanControlBudget))
                return new BudgetResult("Access denited");
            var receiptsByBudget = await _receiptRepository.FindListAsTrackingAsync(x => x.BudgetId == budgetForRemove.Id);
            receiptsByBudget.ForEach(x =>
            {
                x.BudgetId = null;
            });
            await _receiptRepository.UpdateRangeAsync(receiptsByBudget);
            await _budgetRepository.RemoveAsync(budgetForRemove);
            return new BudgetResult(_mapper.Map<BudgetViewModel>(budgetForRemove));
        }
    }
}