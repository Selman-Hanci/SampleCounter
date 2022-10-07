using System;
using Microsoft.Extensions.Logging;

namespace SampleBusiness.Services.Interfaces
{
    public interface ILogService
    {
        void Log(LogLevel logLevel, string message);
    }
}

