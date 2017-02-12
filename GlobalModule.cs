using Nancy;

namespace SampleNancy
{
    public class CollectorModule : NancyModule
    {
        public CollectorModule(IService service)
        {
            Get("/", args => $"Service is{(service.IsRunning ? string.Empty : " not")} working.");
            Get("/service/start", args => service.Start());
            Get("/service/stop", args => service.Stop());
        }
    }
}