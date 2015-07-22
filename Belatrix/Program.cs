using Belatrix.Logger;
using System;

namespace Belatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            JobLogger.Instance.Setup(logToFile: true, logError: true);

            JobLogger.Instance.LogMessage("Some error", MessageType.Error);
            JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
            JobLogger.Instance.LogMessage("Some message", MessageType.Message);
           
            Console.Read();
        }
    }
}
