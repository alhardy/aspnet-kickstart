using System.IdentityModel.Tokens.Jwt;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNet.Builder;

namespace AspNet.KickStart.ApiHost
{
    // ReSharper disable MissingXmlDoc
    public static class AuthenticationExtensions
        // ReSharper restore MissingXmlDoc
    {
        public static IApplicationBuilder UseOAuth2(this IApplicationBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseIdentityServerAuthentication(options =>
            {
                options.Authority = "https://auth";
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.SupportedTokens = SupportedTokens.Both;
                options.ScopeName = "seems to be required when reference tokens are allowed";
            });

            return app;
        }
    }
}