using Microsoft.Extensions.Logging;

namespace SampleNancy
{
    public interface IService
    {
        bool Start();
        bool IsRunning { get; }
        bool Stop();
    }

    public class Service : IService
    {
        public bool IsRunning => true;

        private ILogger logger;

        public Service(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<Service>();
        }

        public bool Start()
        {
            logger.LogTrace("Staring service");
            // service logic
            logger.LogTrace("Started service");
            return true;
        }

        public bool Stop()
        {
            logger.LogTrace("Stopping service");
            return true;
        }
    }
}