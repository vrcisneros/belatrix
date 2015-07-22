using Belatrix.Logger;
using System;

public class JobLogger
{
    private static volatile JobLogger instance = null;
    private static readonly object padlock = new object();

    // We can get initial values from config file
    private bool _logToFile = false;
    private bool _logToConsole = false;
    private bool _logToDatabase = false;
    private bool _logMessage = false;
    private bool _logWarning = false;
    private bool _logError = false;

    protected JobLogger()
    {

    }

    public static JobLogger Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new JobLogger();

                return instance;
            }
        }

    }

    public void Setup(
        bool? logToFile = null,
        bool? logToConsole = null,
        bool? logToDatabase = null,
        bool? logMessage = null, 
        bool? logWarning = null,
        bool? logError = null)
    {
        _logToFile = logToFile ?? _logToFile;
        _logToConsole = logToConsole ?? _logToConsole;
        _logToDatabase = logToDatabase ?? _logToDatabase;

        _logMessage = logMessage ?? _logMessage;
        _logWarning = logWarning ?? _logWarning;
        _logError = logError ?? _logError;
    }

    public bool LogMessage(string message, MessageType type)
    {
        message = message.Trim();

        if (string.IsNullOrEmpty(message))
        {
            return false;
        }

        if (!_logToConsole && !_logToFile && !_logToDatabase)
        {
            throw new Exception("Invalid configuration");
        }

        switch (type)
        {
            case MessageType.Message:
                if (_logMessage)
                {
                    LogInSource(message, type);
                    return true;
                }
                break;
            case MessageType.Error:
                if (_logError)
                {
                    LogInSource(message, type);
                    return true;
                }
                break;
            case MessageType.Warning:
                if (_logWarning)
                {
                    LogInSource(message, type);
                    return true;
                }
                break;
            default:
                return false;
        }

        return false;
    }

    private void LogInSource(string message, MessageType type)
    {
        if (_logToConsole) { new ConsoleLogger().LogMessage(message, type); }
        if (_logToFile) { new FileLogger().LogMessage(message, type); }
        if (_logToDatabase) { new DatabaseLogger().LogMessage(message, type); }
    }
}