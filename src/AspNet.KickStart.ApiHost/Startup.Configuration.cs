using Microsoft.AspNetCore.Hosting;
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
               .SetBasePath(env.WebRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }


            return builder.Build();
        }

        public static IHostingEnvironment ConfigureLogger(this IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var logConfig = new ConfigurationBuilder()
                .SetBasePath(env.WebRootPath)
                .AddJsonFile("logsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();
            loggerFactory.AddConsole(logConfig);

            return env;
        }
    }
}