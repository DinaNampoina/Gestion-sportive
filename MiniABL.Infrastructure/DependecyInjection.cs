using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniABL.Infrastructure.Percistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniABL.Infrastructure
{
    public static  class DependecyInjection
    {
        public static IServiceCollection AddInfrasreuctureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
