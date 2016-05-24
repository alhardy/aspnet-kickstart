using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

namespace AspNet.KickStart.ApiHost
{
    // ReSharper disable MissingXmlDoc
    public static class AuthenticationExtensions
    // ReSharper restore MissingXmlDoc
    {
        public static IApplicationBuilder AddAuthz(this IApplicationBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Authority = "https://localhost:1234",
                Audience = "https://localhost:1234/resources",

                RequireHttpsMetadata = true,
                AutomaticAuthenticate = true,

                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                }
            });

            return app;
        }
    }
}