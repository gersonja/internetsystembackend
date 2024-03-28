using Microsoft.AspNetCore.Mvc.Filters;

namespace InternetSystem.Filters
{
    public class SessionUserFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("SessionUserFilter");
            await next();
        }
    }
}
