using System.Collections.Generic;
namespace Ereceipt.Web.Models
{
    internal class ListRoutes<T>
    {
        public ListRoutes()
        {
        }

        public bool Success { get; internal set; }
        public int Count { get; internal set; }
        public List<RouteModel> Items { get; internal set; }
    }
}