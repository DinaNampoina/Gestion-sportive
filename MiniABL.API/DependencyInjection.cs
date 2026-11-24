using MiniABL.Application;
using MiniABL.Infrastructure;

namespace MiniABL.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPIDI(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddInfrasreuctureDI(configuration)
                .AddApplicationDI();
            return services;
        }
    }
}
