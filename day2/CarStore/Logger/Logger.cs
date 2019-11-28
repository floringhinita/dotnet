using System;
using System.Configuration;

namespace CarStore.Logger
{
    public static class Log
    {
        private static readonly AbstractLogger logger;
        private static readonly int debug;
        static Log()
        {
            string debugOutput = ConfigurationManager.AppSettings["debugOutput"];

            debug = Int32.Parse(ConfigurationManager.AppSettings["debug"]);

            switch (debugOutput)
            {
                case "file":
                    logger = new FileLogger();
                    break;
                case "console":
                default:
                    logger = new ConsoleLogger();
                    break;
            }
        }

        public static void Info(string message)
        {
            if (debug == 1)
            {
                logger.Log(message);
            }
        }
    }
}
