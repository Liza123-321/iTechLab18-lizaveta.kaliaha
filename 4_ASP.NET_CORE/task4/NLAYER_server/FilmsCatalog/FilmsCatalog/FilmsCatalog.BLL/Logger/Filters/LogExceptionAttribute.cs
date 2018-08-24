using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.BLL.Logger.Filters
{
    public class LogExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly ILog4NetService _log4net;
        public LogExceptionAttribute(ILog4NetService log4NetService)
        {
            this._log4net = log4NetService;
        }

        public override void OnException(ExceptionContext context)
        {
            _log4net.LogException(context.Exception);
        }
    }
}
