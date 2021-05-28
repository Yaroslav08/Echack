using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ereceipt.Application.ViewModels.Budget
{
    public class BudgetRemoveModel : RequestModel
    {
        public long BudgetId { get; set; }

        public BudgetRemoveModel(long budgetId)
        {
            BudgetId = budgetId;
        }
    }
}
