using Ereceipt.Application.MediatR.Queries;
using Ereceipt.Application.Results.BudgetCategories;
using Ereceipt.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ereceipt.Application.MediatR.Queries
{
    public class GetCategoryByIdQuery : IRequest<BudgetCategoryResult>
    {
        public GetCategoryByIdQuery(long id, bool withReceipts)
        {
            Id = id;
            WithReceipts = withReceipts;
        }

        public long Id { get; set; }
        public bool WithReceipts { get; set; }
    }
}

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, BudgetCategoryResult>
{
    private readonly IBudgetCategoryService _budgetCategoryService;
    public GetCategoryByIdQueryHandler(IBudgetCategoryService budgetCategoryService)
    {
        _budgetCategoryService = budgetCategoryService;
    }

    public async Task<BudgetCategoryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _budgetCategoryService.GetCategoryByIdAsync(request.Id, request.WithReceipts);
    }
}
