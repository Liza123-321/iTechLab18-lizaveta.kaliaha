using System;
using System.IO;

namespace ConsoleApp1
{
    public class ServiceLogger
    {
        public void WriteToFile(string Message)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";

            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
