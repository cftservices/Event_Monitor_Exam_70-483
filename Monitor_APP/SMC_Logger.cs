using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_APP
{
    class SMC_Logger : IMessage
    {




        public string LogMessage { get; set; }



        public string ReadMessage()
        {
            // Read SMC Message




            Console.WriteLine("");


            return LogMessage;
        }
    }
}
