using Ereceipt.Web.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ereceipt.Web.Filters
{
    public class ModelStateValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            var model = actionExecutingContext.ModelState;
            if (!model.IsValid)
            {
                actionExecutingContext.Result = new BadRequestObjectResult(new APIBadRequestResponse("Model not valid", model));
            }
        }
    }
}
