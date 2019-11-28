using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Logger
{
    class ConsoleLogger : AbstractLogger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
