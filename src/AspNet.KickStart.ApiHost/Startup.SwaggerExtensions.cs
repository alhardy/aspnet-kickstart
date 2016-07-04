// ReSharper disable CheckNamespace

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Builder
// ReSharper restore CheckNamespace
{
    public static class SwaggerExtensions
    {
        public static IApplicationBuilder UseSwaggerDefaults(this IApplicationBuilder app)
        {
            app.UseSwagger((request, document) =>
            {
                document.Schemes = new[] { "http", "https" };
                document.Consumes = new List<string>(new []{"application/json"});
                document.Produces = new List<string>(new[] { "application/json" });
            });
            app.UseSwaggerUi();

            return app;
        }
    }
}