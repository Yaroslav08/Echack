using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetActiveBudgetsQuery : IRequest<ListBudgetResult>
    {
        public GetActiveBudgetsQuery(Guid groupId)
        {
            GroupId = groupId;
        }
        public Guid GroupId { get; set; }
    }
    public class GetActiveBudgetsQueryHandler : IRequestHandler<GetActiveBudgetsQuery, ListBudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public GetActiveBudgetsQueryHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public async Task<ListBudgetResult> Handle(GetActiveBudgetsQuery request, CancellationToken cancellationToken)
        {
            return await _budgetService.GetActiveBudgetsAsync(request.GroupId);
        }
    }
}