using Microsoft.AspNet.Builder;

namespace AspNet.KickStart.ApiHost
{
    // ReSharper disable MissingXmlDoc
    public static class DevelopmentExtensions
    // ReSharper restore MissingXmlDoc
    {
        public static IApplicationBuilder ConfigureForDevelopment(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRuntimeInfoPage("/info");

            return app;
        }
    }
}