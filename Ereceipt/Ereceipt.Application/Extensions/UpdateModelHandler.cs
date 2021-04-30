using Ereceipt.Application.ViewModels;
using Ereceipt.Domain.Models;
using System;
namespace Ereceipt.Application.Extensions
{
    public static class UpdateModelHandler
    {
        public static void SetUpdateData(this BaseModel model, RequestModel requestModel)
        {
            model.UpdatedAt = DateTime.UtcNow;
            model.UpdatedBy = requestModel.UserId.ToString();
        }
    }
}