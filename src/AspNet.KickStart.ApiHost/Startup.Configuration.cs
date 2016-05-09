using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNet.KickStart.ApiHost
{
    // ReSharper disable MissingXmlDoc
    public static class EnvConfigurationExtensions
    // ReSharper restore MissingXmlDoc
    {
        public static IConfigurationRoot BuildConfiguration(this IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        public static IHostingEnvironment ConfigureLogger(this IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var logConfig = new ConfigurationBuilder().AddJsonFile("logsettings.json").Build();
            logConfig.ReloadOnChanged("logsettings.json");
            loggerFactory.AddConsole(logConfig);

            return env;
        }
    }
}