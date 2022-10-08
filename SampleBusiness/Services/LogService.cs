using Microsoft.Extensions.Logging;
using SampleBusiness.Services.Interfaces;
using System.Net.Http;

namespace SampleBusiness.Services
{
    public class LogService: ILogService
    {
        public LogService()
        {
        }

        public void Log(LogLevel logLevel, string message)
        {
            //Implementation for logging
        }
    }
}

