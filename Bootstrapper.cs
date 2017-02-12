using System;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.Diagnostics;
using Nancy.TinyIoc;

namespace SampleNancy
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private IServiceProvider serviceProvider;

        public Bootstrapper(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(enabled: true, displayErrorTraces: true);
            environment.Diagnostics(
                enabled: true,
                password: "12345");
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Resolve<IService>().Start();
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(serviceProvider.GetService(typeof(ILoggerFactory)) as ILoggerFactory);
        }
    }
}