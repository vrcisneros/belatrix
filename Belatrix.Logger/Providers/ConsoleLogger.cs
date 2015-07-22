using System;

namespace Belatrix.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Message: Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageType.Error: Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageType.Warning: Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }

            Console.WriteLine("{0} {1}", DateTime.Now.ToShortDateString(), message);
        }
    }
}
