using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using MediatR;
using Identity.IntegrationEvent;
using Leasing.Application.Commands;

namespace Leasing.Application.EventHandler.Integration
{


    public class UserCreatedIntegrationEventHandler : INotificationHandler<UserCreatedIntegrationEvent>
    {
        private readonly ITenantCommands _tenantCommands;

        public UserCreatedIntegrationEventHandler(ITenantCommands tenantCommands)
        {
            _tenantCommands = tenantCommands;
        }

        public async Task Handle(UserCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {


            if (notification.Role == "Tenant")
            {
                await _tenantCommands.AddTenantAsync(
                 notification.Id,
                 notification.Email,
                 notification.Name,
                 notification.Address,
                 notification.Gender,
                 notification.ContactNumber,
                 cancellationToken);
            }
            else
            {
                return;
            }
         
           
        }
    }
}
