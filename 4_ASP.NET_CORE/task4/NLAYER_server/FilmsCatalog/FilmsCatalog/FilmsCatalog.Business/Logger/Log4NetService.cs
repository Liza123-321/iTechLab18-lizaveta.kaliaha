using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsCatalog.Business.Logger
{
    public class Log4NetService : ILog4NetService
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(Log4NetService));
        public void LogAction(ActionExecutedContext logMeassge)
        {
            _log.Info(logMeassge.HttpContext.Request.Method + " " + logMeassge.HttpContext.Request.Path + " " + logMeassge.HttpContext.Request.Protocol + " Action: " + logMeassge.ActionDescriptor.DisplayName);
        }
        public void LogException(Exception logException)
        {
            _log.Error("Exception: " + logException.Message + " " + logException.Source + " " + logException.HelpLink);
        }
    }
}
