using System;
using System.IO;

namespace CarStore.Logger
{
    class FileLogger : AbstractLogger
    {
        private string filePath;

        public FileLogger()
        {
            this.filePath = Directory.GetCurrentDirectory() + "/log.tmp";
        }

        public FileLogger(string filePath)
        {
            // check if file exists
            this.filePath = filePath;
        }

        public override void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
