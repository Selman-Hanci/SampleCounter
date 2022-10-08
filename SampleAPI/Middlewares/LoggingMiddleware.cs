using System;
using SampleBusiness.Services.Interfaces;

namespace SampleAPI.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logger;

        public LoggingMiddleware(RequestDelegate next, ILogService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Log the incoming request path
            _logger.Log(LogLevel.Information, context.Request.Path);

            //Invoke the next middleware in the pipeline
            await _next(context);

            //Get distinct response headers
            var uniqueResponseHeaders
                = context.Response.Headers
                                  .Select(x => x.Key)
                                  .Distinct();

            //Log these headers
            _logger.Log(LogLevel.Information, string.Join(", ", uniqueResponseHeaders));
        }
    }
}

