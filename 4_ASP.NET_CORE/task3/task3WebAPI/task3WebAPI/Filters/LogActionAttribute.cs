using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task3WebAPI.MyLogger;

namespace task3WebAPI.Filters
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        private readonly IMyFileLogger _logger;
        private readonly ILog4netService _log4net;
        public LogActionAttribute(IMyFileLogger logger, ILog4netService log4NetService)
        {
            this._logger = logger;
            this._log4net = log4NetService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Log(context);
            _log4net.LogAction(context);
        }
    }
}
