using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor_APP;

namespace Monitor_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            SMC_Logger SMC_Log = new SMC_Logger();

            SMC_Log.ReadMessage();


        }
    }
}
