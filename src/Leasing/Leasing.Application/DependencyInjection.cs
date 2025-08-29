using Leasing.Application.CommandHandler;
using Leasing.Application.Commands;
using Microsoft.Extensions.DependencyInjection;


namespace Leasing.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddLeasingApplication(this IServiceCollection services)
        {
            // Register Services
            services.AddScoped<ITenantCommands, TenantCommands>();
            services.AddScoped<ILeasingCommands, LeasingCommands>();
            services.AddScoped<IInvoiceCommands, InvoiceCommands>();
            services.AddScoped<IPaymentReceiptCommands, PaymentReceiptCommands>();

            return services;
        }
    }
}
