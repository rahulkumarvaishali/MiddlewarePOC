using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddlewarePOC.Middlewares
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UseRequestResponseLoggingAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new RequestResponseLoggingFilter(serviceProvider.GetRequiredService<ILogger<RequestResponseLoggingFilter>>());
        }

        public bool IsReusable => true;
    }
}
