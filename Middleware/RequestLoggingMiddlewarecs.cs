using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REQUESTLOGGER.Middleware
{

    public class RequestLoggingMiddleware : IMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Log the incoming request method and path
            _logger.LogInformation($"Request Method: {context.Request.Method}, Path: {context.Request.Path}");

            // Call the next middleware in the pipeline
            await next(context);
        }
    }
}
