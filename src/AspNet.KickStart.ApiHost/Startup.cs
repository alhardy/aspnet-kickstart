using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNet.KickStart.ApiHost
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = env.BuildConfiguration();
        }

        public IConfigurationRoot Configuration { get; set; }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.ConfigureLogger(loggerFactory);

            app.UseIISPlatformHandler();

            if (env.IsDevelopment())
            {
                app.ConfigureForDevelopment();
            }

            app.ConfigureSecurity();
            app.UseMvcWithMetrics();
            app.UseOAuth2();

            app.UseStaticFiles();
            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging()
                .AddRouting(options => { options.LowercaseUrls = true; })
                .AddSwagger()
                .AddCaching();

            services
                .AddMvc()
                .AddDefaultJsonOptions();

            services
                .AddMetrics(options =>
                {
                    options.MetricsEndpoint = new PathString("/metrics");
                    options.MetricsVisualisationEnabled = false;
                })
                .AddAllPerforrmanceCounters()
                .AddHealthChecks();

            return services.BuildServiceProvider();
        }
    }
}