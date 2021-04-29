using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ereceipt.Application.ViewModels.Currency
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Code { get; set; }
        public int ISOFormat { get; set; }
        public string Name { get; set; }
        public string Countries { get; set; }
    }
}