using Ecommerce.Application.Utilities;
using Ecommerce.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped<IPasswordHash, PasswordHash>();
            services.AddScoped<IJwtServiceUtility, JwtServiceUtility>();
            return services;
        }
    }
       
}
