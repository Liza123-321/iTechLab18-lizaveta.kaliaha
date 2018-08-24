using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilmsCatalog.BLL.Logger
{
    public interface ILog4NetService
    {
        void LogAction(ActionExecutedContext logMeassge);
        void LogException(Exception logException);
    }
}
