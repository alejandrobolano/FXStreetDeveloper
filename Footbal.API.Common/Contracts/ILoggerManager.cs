using System;
using System.Collections.Generic;
using System.Text;

namespace Football.API.Common.Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message, string className, int line = 0);
    }
}
