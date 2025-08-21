using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Property.Application.Queries;
using Property.Domain.Repositories;
using Property.Infrastracture.Data;
using Property.Infrastracture.Data.Repositories;
using Property.Infrastracture.QueryHandler;

namespace Property.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //Register ContextDB
            services.AddDbContext<PropertyDbContext>(o =>
            {
                o.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Property"));
            });

          
            // Register Repositories
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IBuildingQueries, BuildingQueries>();
            services.AddScoped<IUnitQueries, UnitQueries>();


            return services;
        }
    }
}
