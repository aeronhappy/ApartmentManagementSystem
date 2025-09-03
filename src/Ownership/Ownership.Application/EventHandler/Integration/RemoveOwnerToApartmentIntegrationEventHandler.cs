using MediatR;
using Ownership.Domain.Entities;
using Ownership.Domain.Repositories;
using Ownership.Domain.ValueObjects;
using Property.IntegrationEvent;

namespace Ownership.Application.EventHandler.Integration
{


    public class RemoveOwnerToApartmentIntegrationEventHandler : INotificationHandler<RemoveOwnerToApartmentIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOwnerToApartmentIntegrationEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveOwnerToApartmentIntegrationEvent notification, CancellationToken cancellationToken)
        {

            if (notification == null)
                return;

            await _unitOfWork.Owners.RemoveOwnerToUnitAsync(
                apartmentId: new ApartmentId(notification.ApartmentId),
                ownerId: new OwnerId(notification.OwnerId));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
