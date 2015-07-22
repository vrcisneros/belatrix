using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace Belatrix.Logger
{
    public class FileLogger : ILogger
    {
        public void LogMessage(string message, MessageType type)
        {
            string fileName = string.Format("{0}LogFile_{1}.txt", ConfigurationManager.AppSettings["LogFileDirectory"], DateTime.Now.ToString("yyyyMMdd"));
            StringBuilder builder = new StringBuilder();

            if (File.Exists(fileName))
            {
                builder = new StringBuilder(File.ReadAllText(fileName));
            }

            builder.AppendFormat("{0} {1} {2}", DateTime.Now.ToShortDateString(), message, Environment.NewLine);

            File.WriteAllText(fileName, builder.ToString());
        }
    }
}
