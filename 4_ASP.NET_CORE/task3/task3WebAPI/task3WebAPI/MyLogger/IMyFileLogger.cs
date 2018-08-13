using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task3WebAPI.MyLogger
{
    public interface IMyFileLogger
    {
        void Log(ActionExecutedContext context);
    }
}
