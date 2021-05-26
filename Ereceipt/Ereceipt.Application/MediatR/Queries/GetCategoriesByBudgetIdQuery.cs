using Ereceipt.Application.Results.BudgetCategories;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetCategoriesByBudgetIdQuery : IRequest<ListBudgetCategoryResult>
    {
        public GetCategoriesByBudgetIdQuery(int id, Guid? groupId)
        {
            Id = id;
            GroupId = groupId;
        }

        public int Id { get; set; }
        public Guid? GroupId { get; set; }
    }

    public class GetCategoriesByBudgetIdQueryHandler : IRequestHandler<GetCategoriesByBudgetIdQuery, ListBudgetCategoryResult>
    {
        private readonly IBudgetCategoryService _budgetCategoryService;
        public GetCategoriesByBudgetIdQueryHandler(IBudgetCategoryService budgetCategoryService)
        {
            _budgetCategoryService = budgetCategoryService;
        }
        public async Task<ListBudgetCategoryResult> Handle(GetCategoriesByBudgetIdQuery request, CancellationToken cancellationToken)
        {
            return await _budgetCategoryService.GetCategoriesByBudgetIdAsync(request.Id, request.GroupId);
        }
    }
}
