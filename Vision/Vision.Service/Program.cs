using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vision.Service
{
     class Program
    {
        static void Main(string[] args)
        {

            ActivityLogger _al = new ActivityLogger();

            while (true)
            {
                _al.OnTimer();
                Thread.Sleep(ActivityLogger.TIMER_INTERVAL_SEC * 1000);

            }
        }
    }
}
