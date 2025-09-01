using Identity.IntegrationEvent;
using MediatR;
using Ownership.Application.Commands;

namespace Ownership.Application.EventHandler.Integration
{


    public class UserCreatedIntegrationEventHandler : INotificationHandler<UserCreatedIntegrationEvent>
    {
        private readonly IOwnerCommands _ownerCommands;

        public UserCreatedIntegrationEventHandler(IOwnerCommands ownerCommands)
        {
            _ownerCommands = ownerCommands;
        }

        public async Task Handle(UserCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Role == "Owner")
            {
                await _ownerCommands.AddOwnerAsync(
                     notification.Id,
                     notification.Email,
                     notification.Name,
                     notification.Address,
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
