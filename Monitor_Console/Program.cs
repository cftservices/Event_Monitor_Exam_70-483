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

            SMC_Logger_Info SMC_Log = new SMC_Logger_Info();
            SMC_Log.ReadMessage();

            //1. collect the messages
            //2. sort the messages
            //3. count the amount of type of the message
            //4. use the task functions.
            //5. use parallel.foreach in order to loop through the messages and do some sorting or alerting on specific content/type message
            //6. skill X.X uit C# boek
        }
    }
}
