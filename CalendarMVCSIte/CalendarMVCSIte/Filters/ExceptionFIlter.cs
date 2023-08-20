using CalendarMVCSIte.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CalendarMVCSIte.Filters
{
    public class ExceptionFIlter : IExceptionFilter
    {
        private readonly ILogger<HomeController> _logger;


        public ExceptionFIlter(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var request = context.HttpContext.Request;

            _logger.Log(LogLevel.Error, context.Exception, $"Error happened during request {request.Path}");
        }
    }
}
