using AutoMapper;
using Ereceipt.Application.Extensions;
using Ereceipt.Application.Results.BudgetCategories;
using Ereceipt.Application.Services.Interfaces;
using Ereceipt.Application.ViewModels.BudgetCategory;
using Ereceipt.Application.Wrappers;
using Ereceipt.Domain.Interfaces;
using Ereceipt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ereceipt.Application.Services.Implementations
{
    public class BudgetCategoryService : IBudgetCategoryService
    {
        private readonly IBudgetCategoryRepository _budgetCategoryRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _mapper;
        private readonly IGroupMemberCheck _groupMemberCheck;
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IReceiptRepository _receiptRepository;
        public BudgetCategoryService(IBudgetCategoryRepository budgetCategoryRepository, IMapper mapper, IGroupMemberCheck groupMemberCheck, IGroupMemberRepository groupMemberRepository, IReceiptRepository receiptRepository, IBudgetRepository budgetRepository)
        {
            _budgetCategoryRepository = budgetCategoryRepository;
            _mapper = mapper;
            _groupMemberCheck = groupMemberCheck;
            _groupMemberRepository = groupMemberRepository;
            _receiptRepository = receiptRepository;
            _budgetRepository = budgetRepository;
        }

        public async Task<BudgetCategoryResult> AddReceiptToCategoryAsync(BudgetReceiptCreateModel model)
        {
            var receipt = await _receiptRepository.FindAsync(x => x.Id == model.ReceiptId);
            if (receipt is null)
                return new BudgetCategoryResult("Receipt not found");
            if (receipt.UserId != model.UserId)
                return new BudgetCategoryResult("Access denited");
            if (receipt.BudgetCategoryId == model.BudgetCategoryId)
                return new BudgetCategoryResult("This receipt is already exist in this category");
            if (receipt.BudgetCategoryId != null)
                return new BudgetCategoryResult("This receipt is already exist in other category");
            var budgetCategory = await _budgetCategoryRepository.FindAsync(x => x.Id == model.BudgetCategoryId);
            if (budgetCategory is null)
                return new BudgetCategoryResult("Budget category not found");
            var budget = await _budgetRepository.FindAsTrackingAsync(x => x.Id == budgetCategory.BudgetId);
            if (budget.Balance < (int)receipt.TotalPrice)
                return new BudgetCategoryResult("The balance in this category is crowded");
            receipt.BudgetCategoryId = budgetCategory.Id;
            await _receiptRepository.UpdateAsync(receipt);
            budget.Balance = budget.Balance - (int)receipt.TotalPrice;
            await _budgetRepository.UpdateAsync(budget);
            return new BudgetCategoryResult(_mapper.Map<BudgetCategoryViewModel>(budgetCategory));
        }

        public async Task<BudgetCategoryResult> CreateBudgetCategoryAsync(BudgetCategoryCreateModel model)
        {
            var currentMember = await _groupMemberRepository.GetGroupMemberByIdAsync(model.GroupId, model.UserId);
            if (!_groupMemberCheck.CanMakeAction(currentMember, GroupActionType.CanControlBudget))
                return new BudgetCategoryResult("Access denited");
            var newBudgetCategory = new BudgetCategory
            {
                Name = model.Name,
                BudgetId = model.BudgetId,
                Description = model.Description
            };
            newBudgetCategory.SetInitData(model);
            return new BudgetCategoryResult(_mapper.Map<BudgetCategoryViewModel>(await _budgetCategoryRepository.CreateAsync(newBudgetCategory)));
        }

        public async Task<BudgetCategoryResult> EditBudgetCategoryAsync(BudgetCategoryEditModel model)
        {
            var budgetCategoryToSave = await _budgetCategoryRepository.FindAsTrackingAsync(x => x.Id == model.Id);
            if (budgetCategoryToSave == null)
                return new BudgetCategoryResult("BudgetCategory not found");
            var currentMember = await _groupMemberRepository.GetGroupMemberByIdAsync(model.GroupId, model.UserId);
            if(!_groupMemberCheck.CanMakeAction(currentMember, GroupActionType.CanControlBudget))
                return new BudgetCategoryResult("Access denited");
            budgetCategoryToSave.Name = model.Name;
            budgetCategoryToSave.Description = model.Description;
            budgetCategoryToSave.SetUpdateData(model);
            return new BudgetCategoryResult(_mapper.Map<BudgetCategoryViewModel>(await _budgetCategoryRepository.UpdateAsync(budgetCategoryToSave)));
        }

        public async Task<ListBudgetCategoryResult> GetCategoriesByBudgetIdAsync(int id, Guid? groupId = null)
        {
            var categories = await _budgetCategoryRepository.FindListAsync(x => x.BudgetId == id);
            return new ListBudgetCategoryResult(_mapper.Map<List<BudgetCategoryViewModel>>(categories));
        }

        public async Task<BudgetCategoryResult> GetCategoryByIdAsync(long id, bool withReceipts = false)
        {
            var category = await _budgetCategoryRepository.GetBudgetCategoryByIdAsync(id, withReceipts);
            return new BudgetCategoryResult(_mapper.Map<BudgetCategoryViewModel>(category));
        }

        public async Task<BudgetCategoryResult> RemoveBudgetCategoryAsync(BudgetCategoryDeleteModel model)
        {
            var currentMember = await _groupMemberRepository.GetGroupMemberByIdAsync(model.GroupId, model.UserId);
            if (!_groupMemberCheck.CanMakeAction(currentMember, GroupActionType.CanControlBudget))
                return new BudgetCategoryResult("Access denited");
            var budgetCategoryForRemove = await _budgetCategoryRepository.FindAsTrackingAsync(x => x.Id == model.BudgetCategoryId);
            await _budgetCategoryRepository.RemoveAsync(budgetCategoryForRemove);
            return new BudgetCategoryResult(_mapper.Map<BudgetCategoryViewModel>(budgetCategoryForRemove));
        }

        public async Task<BudgetCategoryResult> RemoveReceiptFromCategoryAsync(BudgetReceiptRemoveModel model)
        {
            var receipt = await _receiptRepository.FindAsTrackingAsync(x => x.Id == model.ReceiptId);
            if (receipt is null)
                return new BudgetCategoryResult("Receipt not found");
            if (receipt.BudgetCategoryId == null)
                return new BudgetCategoryResult("Receipt don't have any category");
            if (receipt.UserId != model.UserId)
                return new BudgetCategoryResult("Access denited");
            var budgetCategory = await _budgetCategoryRepository.FindAsync(x => x.Id == model.BudgetCategoryId);
            if (budgetCategory is null)
                return new BudgetCategoryResult("Budget category not found");
            var budget = await _budgetRepository.FindAsync(x => x.Id == budgetCategory.Id);
            var balance = budget.Balance + (int)receipt.TotalPrice;
            if (balance < 0)
                return new BudgetCategoryResult("Something went wrong");
            budget.Balance = balance;
            await _budgetRepository.UpdateAsync(budget);
            receipt.BudgetCategoryId = null;
            await _receiptRepository.UpdateAsync(receipt);
            return new BudgetCategoryResult(_mapper.Map<BudgetCategoryViewModel>(budgetCategory));
        }
    }
}