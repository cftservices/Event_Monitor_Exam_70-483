using aaLogReader;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Monitor_APP.Interfaces
{
    public interface ISMC_Logger
    {
        void ReadMessage();
    }
}