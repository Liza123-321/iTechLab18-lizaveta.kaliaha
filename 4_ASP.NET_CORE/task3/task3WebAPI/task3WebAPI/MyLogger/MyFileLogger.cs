using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace task3WebAPI.MyLogger
{
    public class MyFileLogger : IMyFileLogger
    {
        private string filePath;
        public MyFileLogger()
        {
            this.filePath = "myLog.txt";
        }

        public void Log(ActionExecutedContext context)
        {
            using (StreamWriter stream = new StreamWriter(filePath, true, System.Text.Encoding.Default))
            {
                stream.WriteLine("_____________________________Do action filter!_____________________________");
                stream.WriteLine(context.HttpContext.Request.Method);
                stream.WriteLine(context.HttpContext.Request.Path);
                stream.WriteLine(context.HttpContext.Request.Protocol);
                if (context.Result is Microsoft.AspNetCore.Mvc.BadRequestObjectResult)
                    stream.WriteLine("___400 Bad Request___");
                stream.WriteLine("Action: "+ context.ActionDescriptor.DisplayName);
                stream.WriteLine("Date: " + DateTime.Now);
            }
        }
    }
}
