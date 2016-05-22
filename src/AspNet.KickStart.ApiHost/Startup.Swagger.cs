using Microsoft.Extensions.DependencyInjection;

namespace AspNet.KickStart.ApiHost
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            //services.AddSwaggerGen();
            //services.ConfigureSwaggerSchema(s =>
            //{
            //    s.DescribeAllEnumsAsStrings = true;
            //    s.IgnoreObsoleteProperties = true;
            //});
            //services.ConfigureSwaggerDocument(s =>
            //{
            //    //TODO: add to config and allow mulitple versions
            //    s.SingleApiVersion(new Info
            //    {
            //        Version = "v1",
            //        Title = "Api-Boot",
            //        Description = "Asp.net api kickstart",
            //        TermsOfService = "TODO"
            //    });
            //    s.IgnoreObsoleteActions = true;
            //});

            return services;
        }
    }
}