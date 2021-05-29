using Ereceipt.Web.Models;
using Ereceipt.Web.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace Ereceipt.Web.Filters
{
    public class ModelStateValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            var model = actionExecutingContext.ModelState;
            if (!model.IsValid)
            {
                var errors = new List<ValidationModel>();
                foreach (var error in model)
                {
                    var listErrors = error.Value.Errors;
                    foreach (var item in listErrors)
                    {
                        errors.Add(new ValidationModel(error.Key, item.ErrorMessage));
                    }
                }
                actionExecutingContext.Result = new BadRequestObjectResult(new APIBadRequestResponse("Model not valid", errors));
            }
        }
    }
}
