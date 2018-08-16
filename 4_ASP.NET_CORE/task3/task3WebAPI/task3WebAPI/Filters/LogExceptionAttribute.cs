using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task3WebAPI.MyLogger;

namespace task3WebAPI.Filters
{
    public class LogExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly IMyFileLogger _logger;
        private readonly ILog4netService _log4net;
        public LogExceptionAttribute(IMyFileLogger logger, ILog4netService log4NetService)
        {
            this._logger = logger;
            this._log4net = log4NetService;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.Error(context.Exception);
            _log4net.LogException(context.Exception);
        }
    }
}
