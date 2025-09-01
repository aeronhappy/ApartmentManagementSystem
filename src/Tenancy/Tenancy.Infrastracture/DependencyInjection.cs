using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tenancy.Application.Queries;
using Tenancy.Domain.Repositories;
using Tenancy.Infrastracture.Data;
using Tenancy.Infrastracture.Data.Repositories;
using Tenancy.Infrastracture.QueryHandler;

namespace Tenancy.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenancyInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //Register ContextDB
            services.AddDbContext<TenancyDbContext>(o =>
            {
                o.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Tenancy"));
            });

          
            // Register Repositories
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ILeasingRepository, LeasingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<ITenantQueries, TenantQueries>();


            return services;
        }
    }
}
