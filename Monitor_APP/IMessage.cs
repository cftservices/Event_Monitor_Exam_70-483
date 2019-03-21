using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_APP
{
    public interface IMessage
    {
        string LogMessage { get; set; }
        string ReadMessage();
    }
}
