using AspNet.Metrics.Infrastructure;
using Microsoft.AspNet.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            env.ConfigureLogger(Configuration, loggerFactory);

            if (env.IsDevelopment())
            {
                app.ConfigureForDevelopment(loggerFactory);
            }

            app.ConfigureSecurity();
            app.AddAuthz();
            app.UseMetrics();
            app.UseMvc();
            app.UseSwaggerDefaults();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOptions()
                .AddLogging()
                .AddRouting(options => { options.LowercaseUrls = true; })
                .AddSwaggerServices();

            services.Configure<AuthSettings>(options =>
                Configuration.GetSection(nameof(AuthSettings)).Bind(options));

            services.AddMvcCore()
                .AddJsonFormatters()
                .AddAuthorization(options =>
                {
                    options.AddPolicy("SamplePolicy", policy => { policy.RequireClaim("scope", "read"); });
                });

            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new MetricsResourceFilter(new DefaultRouteTemplateResolver()));
                })
                .AddDefaultJsonOptions();


            services
                .AddMetrics(options =>
                {
                    options.MetricsEndpoint = new PathString("/metrics");
                    options.MetricsVisualisationEnabled = false;
                })
                .AddAllPerforrmanceCounters()
                .AddHealthChecks();
        }
    }
}