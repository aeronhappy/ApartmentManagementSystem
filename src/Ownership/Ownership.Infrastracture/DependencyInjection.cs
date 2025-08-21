using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ownership.Application.Queries;
using Ownership.Domain.Repositories;
using Ownership.Infrastracture.Data;
using Ownership.Infrastracture.Data.Repositories;
using Ownership.Infrastracture.QueryHandler;

namespace Ownership.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOwnerInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //Register ContextDB
            services.AddDbContext<OwnershipDbContext>(o =>
            {
                o.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Ownership"));
            });


            // Register Repositories
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerQueries, OwnerQueries>();


            return services;
        }
    }
}
