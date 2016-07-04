using Microsoft.Extensions.Logging;

// ReSharper disable MissingXmlDoc
namespace Microsoft.AspNetCore.Builder
// ReSharper restore MissingXmlDoc

{
    public static class DevelopmentExtensions
    {
        public static IApplicationBuilder ConfigureForDevelopment(this IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            loggerFactory.AddDebug();

            return app;
        }
    }
}