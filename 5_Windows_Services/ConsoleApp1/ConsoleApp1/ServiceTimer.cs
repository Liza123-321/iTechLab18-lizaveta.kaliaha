using System;
using System.Linq;
using System.Timers;

namespace ConsoleApp1
{
    public class ServiceTimer
    {
        Timer timer = new Timer();
        ServiceLogger logger = new ServiceLogger();

        public void TimerStart()
        {
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 10000;
            timer.Enabled = true;
            logger.WriteToFile("Service is started at " + DateTime.Now);
        }

        private void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            using (var db = new MyContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var test = db.Wss.Where(i => i.Description == "test").FirstOrDefault();
                        test.Count++;
                        db.SaveChanges();
                        transaction.Commit();
                        logger.WriteToFile("Service is recall at " + DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        logger.WriteToFile("Transaction Error: " + ex);
                    }
                }
            }
        }

        public void TimerStop()
        {
            timer.Enabled = false;
            logger.WriteToFile("Service is stopped at " + DateTime.Now);
        }
    }
}
