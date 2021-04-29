using Ereceipt.Application.ViewModels;
namespace Ereceipt.Application.Extensions
{
    public static class RequestModelHandler
    {
        public static void InitDataRequest(this RequestModel model, int id, string ip)
        {
            model.UserId = id;
            model.IP = ip;
        }
    }
}