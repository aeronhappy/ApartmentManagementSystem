using Microsoft.Extensions.DependencyInjection;
using Ownership.Application.CommandHandler;
using Ownership.Application.Commands;


namespace Ownership.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddOwnerApplication(this IServiceCollection services)
        {
            // Register Services
            services.AddScoped<IOwnerCommands, OwnerCommands>();

            return services;
        }
    }
}
