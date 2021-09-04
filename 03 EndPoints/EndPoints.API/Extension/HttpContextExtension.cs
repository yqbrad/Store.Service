using Microsoft.AspNetCore.Http;
using Store.EndPoints.API.Configuration;

namespace Store.EndPoints.API.Extension
{
    public static class HttpContextExtension
    {
        public static ServiceConfig ServiceContext(this HttpContext httpContext) =>
            (ServiceConfig)httpContext.RequestServices.GetService(typeof(ServiceConfig));
    }
}