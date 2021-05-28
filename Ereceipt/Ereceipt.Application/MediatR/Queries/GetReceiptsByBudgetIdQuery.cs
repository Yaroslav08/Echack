using Ereceipt.Application.Results.Receipts;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetReceiptsByBudgetIdQuery : IRequest<ListReceiptResult>
    {
        public GetReceiptsByBudgetIdQuery(Guid groupId, long budgetId, int skip)
        {
            GroupId = groupId;
            BudgetId = budgetId;
            Skip = skip;
        }
        public Guid GroupId { get; }
        public long BudgetId { get; }
        public int Skip { get; }
    }

    public class GetReceiptsByBudgetIdQueryHandler : IRequestHandler<GetReceiptsByBudgetIdQuery, ListReceiptResult>
    {
        private readonly IBudgetService _budgetService;
        public GetReceiptsByBudgetIdQueryHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }


        public async Task<ListReceiptResult> Handle(GetReceiptsByBudgetIdQuery request, CancellationToken cancellationToken)
        {
            return await _budgetService.GetReceiptsByBudgetAsync(request.GroupId, request.BudgetId, request.Skip);
        }
    }
}
