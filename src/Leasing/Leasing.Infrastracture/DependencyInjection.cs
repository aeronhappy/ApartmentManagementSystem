using Leasing.Application.Queries;
using Leasing.Domain.Repositories;
using Leasing.Infrastracture.Data;
using Leasing.Infrastracture.Data.Repositories;
using Leasing.Infrastracture.QueryHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leasing.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLeasingInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //Register ContextDB
            services.AddDbContext<LeasingDbContext>(o =>
            {
                o.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Leasing"));
            });

          
            // Register Repositories
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ILeasingRepository, LeasingRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IPaymentReceiptRepository, PaymentReceiptRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<ITenantQueries, TenantQueries>();
            services.AddScoped<ILeasingQueries, LeasingQueries>();
            services.AddScoped<IInvoiceQueries, InvoiceQueries>();
            services.AddScoped<IPaymentReceiptQueries, PaymentReceiptQueries>();


            return services;
        }
    }
}
