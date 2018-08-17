using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task3WebAPI
{
    public class Log4netService : ILog4netService
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(Log4netService));
        public void LogAction(ActionExecutedContext logMeassge)
        {
            _log.Info(logMeassge.HttpContext.Request.Method+" " + logMeassge.HttpContext.Request.Path + " " + logMeassge.HttpContext.Request.Protocol+ " Action: "+ logMeassge.ActionDescriptor.DisplayName);
        }
       public void LogException(Exception logException)
        {
            _log.Error("Exception: "+ logException.Message + " "+ logException.Source + " " + logException.HelpLink );
        }
    }
}
