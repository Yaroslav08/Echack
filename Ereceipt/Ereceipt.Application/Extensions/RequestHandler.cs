using Ereceipt.Application.ViewModels;
namespace Ereceipt.Application.Extensions
{
    public static class RequestHandler
    {
        public static void IncomeRequestInit(this RequestModel model, int id, string ip)
        {
            model.UserId = id;
            model.IP = ip;
        }
    }
}