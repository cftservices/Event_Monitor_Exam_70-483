using System;

namespace Monitor_APP
{
    class SMC_Logger : IMessage
    {




        public string LogMessage { get; set; }



        public string ReadMessage()
        {
            // Read SMC Message
            Console.WriteLine("commit test");

            return LogMessage;
        }
    }
}
