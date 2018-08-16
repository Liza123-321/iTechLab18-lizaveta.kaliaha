using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_task4.Logger
{
    public interface ILog4NetService
    {
        void LogAction(ActionExecutedContext logMeassge);
        void LogException(Exception logException);
    }
}
