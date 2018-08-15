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
        public LogActionAttribute(IMyFileLogger logger)
        {
            this._logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Log(context);
        }
    }
}
