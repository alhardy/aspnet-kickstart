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
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }


            return builder.Build();
        }

        public static IHostingEnvironment ConfigureLogger(this IHostingEnvironment env,
            IConfigurationRoot configurationRoot,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(configurationRoot.GetSection("Logging"));

            return env;
        }
    }
}