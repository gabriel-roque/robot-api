using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RobotApi.Middlewares;

public class ExampleMiddleware : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Anywhere logic example
        if (false)
        {
            context.Result = new StatusCodeResult(403);
            return;
        }

        base.OnActionExecuting(context);
    }
}