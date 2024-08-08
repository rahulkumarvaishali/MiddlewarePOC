using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddlewarePOC.Middlewares
{
    public class GetRequestLoggingFilter : IAsyncActionFilter
    {
        private readonly ILogger<GetRequestLoggingFilter> _logger;

        public GetRequestLoggingFilter(ILogger<GetRequestLoggingFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //if (context.HttpContext.Request.Method == HttpMethods.Get)
            //{
                // Log request details
                var requestTime = DateTime.Now;
                var requestMethod = context.HttpContext.Request.Method;
                var requestPath = context.HttpContext.Request.Path;
                _logger.LogInformation($"Request\n Time: {requestTime}\n Method Type: {requestMethod}\n Path: {requestPath}");

                // Call the next delegate/middleware in the pipeline
                var resultContext = await next();

                // Log response details
                var responseTime = DateTime.Now;
                var statusCode = resultContext.HttpContext.Response.StatusCode;
                _logger.LogInformation($"Response\n Time: {responseTime}\n Status Code: {statusCode}");
            //}
            //else
            //{
            //    // Call the next delegate/middleware in the pipeline if not GET
            //    await next();
            //}
        }
    }
}
