using System;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.ErrorHandling;

namespace SampleNancy
{
    public class LoggingStatusCodeHandler : IStatusCodeHandler
    {
        private ILogger logger;

        public LoggingStatusCodeHandler(ILoggerFactory factory)
        {
            this.logger = factory.CreateLogger<LoggingStatusCodeHandler>();
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.InternalServerError;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            object errorObject;
            context.Items.TryGetValue(NancyEngine.ERROR_EXCEPTION, out errorObject);
            var error = errorObject as Exception;

            logger.LogError(LoggingEvents.GLOBAL_ERROR, error, "InternalServerError");
        }
    }
}