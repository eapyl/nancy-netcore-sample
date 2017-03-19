using Nancy;

namespace SampleNancy
{
    public class CollectorModule : NancyModule
    {
        public CollectorModule(IService service)
        {
            Get("/", args => $"Service is{(service.IsRunning ? string.Empty : " not")} working.");
            Get("/service/start", args => Response.AsText(service.Start().ToString()));
            Get("/service/stop", args => Response.AsText(service.Stop().ToString()));
        }
    }
}