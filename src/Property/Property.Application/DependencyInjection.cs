using Microsoft.Extensions.DependencyInjection;
using Property.Application.CommandHandler;
using Property.Application.Commands;


namespace Property.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPropertyApplication(this IServiceCollection services)
        {
            // Register Services
            services.AddScoped<IBuildingCommands, BuildingCommands>();
            services.AddScoped<IApartmentCommands, ApartmentCommands>();

            return services;
        }
    }
}
