// ReSharper disable MissingXmlDoc
namespace Microsoft.AspNetCore.Builder
// ReSharper restore MissingXmlDoc

{
    public static class DevelopmentExtensions
    {
        public static IApplicationBuilder ConfigureForDevelopment(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRuntimeInfoPage("/info");

            return app;
        }
    }
}