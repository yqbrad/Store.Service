using Framework.Domain.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.DomainModels._Exceptions;

namespace Store.EndPoints.API.Filters
{
    public class ExceptionFilter: IExceptionFilter
    {
        //private readonly ILoggerService _loggerService;
        //public ExceptionFilter(ILoggerService loggerService)
        //    => _loggerService = loggerService;

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            var statusCode = StatusCodes.Status500InternalServerError;
            var errorCode = 0;
            var message = "خطای سرور";
            //LogType errorType;

#if DEBUG
            message = ex.ToString();
#endif

            switch (ex)
            {
                case BaseException _:
                    statusCode = 499;
                    //errorType = LogType.Warning;
                    message = ex.Message;
                    errorCode = ex.HResult;
                    break;
                default:
                    //errorType = LogType.Error;
                    break;
            }

            //_loggerService.LogAsync(ex, errorType);

            context.Result = new ObjectResult(new Error(message, errorCode))
            {
                StatusCode = statusCode
            };
        }
    }
}