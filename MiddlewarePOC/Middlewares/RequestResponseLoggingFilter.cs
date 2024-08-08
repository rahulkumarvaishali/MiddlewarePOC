using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace MiddlewarePOC.Middlewares
{
    public class RequestResponseLoggingFilter : IAsyncActionFilter
    {
        private readonly ILogger<RequestResponseLoggingFilter> _logger;

        public RequestResponseLoggingFilter(ILogger<RequestResponseLoggingFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Log the request details
            var requestTime = DateTime.Now;
            var requestMethod = context.HttpContext.Request.Method;
            var requestPath = context.HttpContext.Request.Path;
            _logger.LogInformation($"Request\n Time: {requestTime}\n Method Type: {requestMethod}\n Path: {requestPath}");

            // Call the next delegate/middleware in the pipeline
            var resultContext = await next();

            // Log the response details
            var responseTime = DateTime.Now;
            var statusCode = resultContext.HttpContext.Response.StatusCode;
            _logger.LogInformation($"Response\n Time: {responseTime}\n Status Code: {statusCode}");
        }
    }
}
