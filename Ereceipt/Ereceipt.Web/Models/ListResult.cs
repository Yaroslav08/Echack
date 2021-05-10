using System.Collections.Generic;

namespace Ereceipt.Web.Models
{
    internal class ListResult<T>
    {
        public ListResult()
        {
        }

        public bool Success { get; internal set; }
        public int Count { get; internal set; }
        public List<RouteModel> Items { get; internal set; }
    }
}
