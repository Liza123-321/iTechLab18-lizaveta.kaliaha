using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmsCatalog.Business.Logger
{
    public interface ILog4NetService
    {
        void LogAction(ActionExecutedContext logMeassge);
        void LogException(Exception logException);
    }
}
