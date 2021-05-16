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
        private readonly IMapper _mapper;
        private readonly IGroupMemberCheck _groupMemberCheck;
        private readonly IGroupMemberRepository _groupMemberRepository;
        public BudgetCategoryService(IBudgetCategoryRepository budgetCategoryRepository, IMapper mapper, IGroupMemberCheck groupMemberCheck, IGroupMemberRepository groupMemberRepository)
        {
            _budgetCategoryRepository = budgetCategoryRepository;
            _mapper = mapper;
            _groupMemberCheck = groupMemberCheck;
            _groupMemberRepository = groupMemberRepository;
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
    }
}