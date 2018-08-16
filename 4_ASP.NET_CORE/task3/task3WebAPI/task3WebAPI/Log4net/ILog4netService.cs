using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task3WebAPI
{
    public interface ILog4netService
    {
        void LogAction(ActionExecutedContext logMeassge);
        void LogException(Exception logException);
    }
}
