using Swashbuckle.Swagger.Model;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
// ReSharper restore CheckNamespace
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.DescribeAllEnumsAsStrings();
                setup.IgnoreObsoleteActions();
                setup.IgnoreObsoleteProperties();
                setup.DescribeStringEnumsInCamelCase();

                //TODO: Allow mulitple versions
                setup.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "TEST",
                    Description = "Test",
                    TermsOfService = "TODO"
                });
            });

            return services;
        }
    }
}