// ReSharper disable CheckNamespace
namespace Microsoft.AspNetCore.Builder
// ReSharper restore CheckNamespace
{
    // ReSharper disable MissingXmlDoc
    public static class SecurityExtensions
    // ReSharper restore MissingXmlDoc
    {
        public static IApplicationBuilder ConfigureSecurity(this IApplicationBuilder app)
        {
            app.Use(next =>
            {
                return ctx =>
                {
                    //TODO: Can't seem to remove x-powered-by header here
                    ctx.Response.Headers.Remove("Server");
                    return next(ctx);
                };
            });

            app.UseHsts(options => options.MaxAge().AllResponses()
                .UpgradeInsecureRequests().IncludeSubdomains());
            app.UseXContentTypeOptions();
            app.UseXDownloadOptions();
            app.UseXfo(options => options.SameOrigin());
            app.UseXRobotsTag(options => options.NoIndex().NoFollow());
            app.UseXXssProtection(options => options.EnabledWithBlockMode());

            return app;
        }
    }
}