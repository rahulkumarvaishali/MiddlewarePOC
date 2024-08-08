namespace MiddlewarePOC.Middlewares
{
    public class ResponseTimeMiddleware: IMiddleware
    {
        private readonly ILogger<ResponseTimeMiddleware> _logger;
        public ResponseTimeMiddleware(ILogger<ResponseTimeMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            DateTime startTime = DateTime.Now;
            /*
             * above peace of  code  will be executed when request is sent
            */
            await next(context);

            /*
             * below peace of  code  will be executed when response is sent
            */
            DateTime endTime = DateTime.Now;
            var responseTime = endTime - startTime;

            _logger.LogInformation($"Response Time : {responseTime.TotalMilliseconds}");


        }
    }
}
