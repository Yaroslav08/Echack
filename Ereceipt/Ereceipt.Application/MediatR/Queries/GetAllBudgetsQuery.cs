using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetAllBudgetsQuery : IRequest<ListBudgetResult>
    {
        public Guid GroupId { get; set; }
        public GetAllBudgetsQuery(Guid groupId)
        {
            GroupId = groupId;
        }
    }

    public class GetAllBudgetsQueryHandler : IRequestHandler<GetAllBudgetsQuery, ListBudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public GetAllBudgetsQueryHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public async Task<ListBudgetResult> Handle(GetAllBudgetsQuery request, CancellationToken cancellationToken)
        {
            return await _budgetService.GetAllBudgetsAsync(request.GroupId);
        }
    }
}