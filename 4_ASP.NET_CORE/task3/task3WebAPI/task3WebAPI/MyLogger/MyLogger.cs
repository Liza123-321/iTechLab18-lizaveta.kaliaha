using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace task3WebAPI.MyLogger
{
    public class Logger
    {
        private ILog log = LogManager.GetLogger(AssemblyInfo.Info, "LOGGER");

        public  ILog Log
        {
            get { return log; }
        }

        public  void InitLogger()
        {
            var logRepository = LogManager.GetRepository(AssemblyInfo.Info);
            XmlConfigurator.Configure(logRepository, new FileInfo("../log4net.config"));
        }
    }
}
