using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aaLogReader;

namespace Monitor_APP
{
    public class SMC_Logger_Error : SMC_Logger
    {
        private ConcurrentBag<LogRecord> SMC_Logging = new ConcurrentBag<LogRecord>();

       public SMC_Logger_Error()
       {
            Console.WriteLine("SMC_Logger_Error created");
            //decide what has to happen here? 
        }
            
        public override void ReadMessage()
        {
            Console.WriteLine("Start picking the error messages.");
        }
    }
}
