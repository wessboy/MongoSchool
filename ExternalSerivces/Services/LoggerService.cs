using ExternalSerivces.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSerivces.Services;
public class LoggerService : ILoggerService
{
    private static ILogger logger = LogManager.GetCurrentClassLogger();
    public void LogDebug(string message) => logger.Debug(message);
    public void LogError(string message) => logger.Error(message);
    public void LogInformation(string message) => logger.Info(message);
    public void LogWarning(string message) => logger.Warn(message);
}

