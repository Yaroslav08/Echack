using Ereceipt.Application.Results.Budgets;
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
    public class GetBudgetByIdQuery : IRequest<BudgetResult>
    {
        public GetBudgetByIdQuery(int id, Guid groupId)
        {
            Id = id;
            GroupId = groupId;
        }
        public int Id { get; set; }
        public Guid GroupId { get; set; }
    }
    public class GetBudgetByIdQueryHandler : IRequestHandler<GetBudgetByIdQuery, BudgetResult>
    {
        private readonly IBudgetService _budgetService;
        public GetBudgetByIdQueryHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public async Task<BudgetResult> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _budgetService.GetBudgetByIdAsync(request.Id, request.GroupId);
        }
    }
}