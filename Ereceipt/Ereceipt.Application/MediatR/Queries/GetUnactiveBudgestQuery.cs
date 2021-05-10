using Ereceipt.Application.Results.Budgets;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Ereceipt.Application.MediatR.Queries
{
    public class GetUnactiveBudgestQuery : IRequest<ListBudgetResult>
    {
        public GetUnactiveBudgestQuery(Guid groupId)
        {
            GroupId = groupId;
        }
        public Guid GroupId { get; set; }
    }
    public class GetUnactiveBudgestQueryHandler : IRequestHandler<GetUnactiveBudgestQuery, ListBudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public GetUnactiveBudgestQueryHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public async Task<ListBudgetResult> Handle(GetUnactiveBudgestQuery request, CancellationToken cancellationToken)
        {
            return await _budgetService.GetUnactiveBudgestAsync(request.GroupId);
        }
    }
}