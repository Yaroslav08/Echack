using Ereceipt.Application.ViewModels;
using Ereceipt.Domain.Models;
using System;
namespace Ereceipt.Application.Extensions
{
    public static class DataModelHandler
    {
        public static void SetUpdateData(this BaseModel model, RequestModel requestModel)
        {
            model.LastUpdatedAt = DateTime.UtcNow;
            model.LastUpdatedBy = requestModel.UserId.ToString();
            model.LastUpdatedFromIP = requestModel.IP;
        }

        public static void SetInitData(this BaseModel model, RequestModel requestModel)
        {
            model.CreatedAt = DateTime.UtcNow;
            model.CreatedBy = requestModel.UserId.ToString();
            model.CreatedFromIP = requestModel.IP;
        }
    }
}