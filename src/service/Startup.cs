using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy.Owin;
using Serilog;

namespace SampleNancy
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .MinimumLevel.Verbose()
              .WriteTo.LiterateConsole()
              .WriteTo.RollingFile("log-{Date}.txt")
              .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                        ILoggerFactory loggerfactory,
                        IApplicationLifetime appLifetime)
        {
            loggerfactory.AddSerilog();
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
            app.UseMetrics();
            app.UseOwin(x => x.UseNancy(options =>
            {
                options.Bootstrapper = new Bootstrapper(app.ApplicationServices);
            }));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMetrics()
                .AddJsonSerialization()
                .AddHealthChecks()
                .AddMetricsMiddleware();
        }
    }
}