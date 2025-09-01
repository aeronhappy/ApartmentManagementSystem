using MediatR;
using Ownership.IntegrationEvent;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Application.EventHandler.Integration
{


    public class OwnerCreatedIntegrationEventHandler : INotificationHandler<OwnerCreatedIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerCreatedIntegrationEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OwnerCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            Owner owner = new()
            {
                Id = new OwnerId(notification.OwnerId) ,
                Email = notification.Email,
                Name = notification.Name
            };

            await _unitOfWork.Owners.AddOwnerAsync(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
