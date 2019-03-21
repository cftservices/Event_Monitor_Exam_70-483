using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_APP
{
    public class SMC_Logger_Warning : SMC_Logger
    {
        public SMC_Logger_Warning()
        {
            Console.WriteLine("SMC_Logger_Warning created");
            //decide what has to happen here? 
        }
        public override void ReadMessage()
        {

        }
    }
}
