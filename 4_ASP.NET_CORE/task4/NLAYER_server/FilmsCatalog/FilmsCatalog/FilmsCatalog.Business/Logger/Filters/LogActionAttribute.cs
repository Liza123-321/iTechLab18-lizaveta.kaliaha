using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmsCatalog.Business.Logger.Filters
{
      public class LogActionAttribute : ActionFilterAttribute
    {
        private readonly ILog4NetService _log4net;
        public LogActionAttribute(ILog4NetService log4NetService)
        {
            this._log4net = log4NetService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _log4net.LogAction(context);
        }
    }
}
