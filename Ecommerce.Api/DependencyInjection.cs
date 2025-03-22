using Ecommerce.Application;
using Ecommerce.Core;
using Ecommerce.Infrastructure;

namespace Ecommerce.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI(configuration);

            return services;
        }

  
    }
}
