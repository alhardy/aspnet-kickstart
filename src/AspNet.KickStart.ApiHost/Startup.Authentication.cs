using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AspNet.KickStart.ApiHost
{
    // ReSharper disable MissingXmlDoc
    public static class AuthenticationExtensions
        // ReSharper restore MissingXmlDoc
    {
        public static IApplicationBuilder AddAuthz(this IApplicationBuilder app)
        {
            var authOptions = app.ApplicationServices.GetService(typeof(IOptions<AuthSettings>)) 
                as IOptions<AuthSettings>;

            if (authOptions == null)
            {
                throw new ApplicationException("Could not resolve AuthSettings Options");
            }

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Authority = authOptions.Value.Authority.ToString(),
                Audience = $"{authOptions.Value.Authority}/resources",
                RequireHttpsMetadata = true,
                AutomaticAuthenticate = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role",
                    ValidateIssuer = true,
                }
            });

            return app;
        }
    }
}