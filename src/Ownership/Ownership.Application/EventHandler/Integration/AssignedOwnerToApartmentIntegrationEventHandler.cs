using MediatR;
using Ownership.Domain.Entities;
using Ownership.Domain.Repositories;
using Ownership.Domain.ValueObjects;
using Property.IntegrationEvent;

namespace Ownership.Application.EventHandler.Integration
{


    public class AssignedOwnerToApartmentIntegrationEventHandler : INotificationHandler<AssignedOwnerToApartmentIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignedOwnerToApartmentIntegrationEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AssignedOwnerToApartmentIntegrationEvent notification, CancellationToken cancellationToken)
        {

            if (notification == null)
                return;
             var ownerId = new OwnerId(notification.OwnerId);
            Apartment apartment = new()
            {
                Id = new ApartmentId(notification.ApartmentId),
                BuildingId = notification.BuildingId,
                BuildingName = notification.BuildingName,
                Name = notification.Name,
                Number = notification.Number,
                Floor = notification.Floor,
                AreaSqm = notification.AreaSqm,
                Status = notification.Status
            };


            await _unitOfWork.Owners.AddUnitToOwnerAsync(ownerId, apartment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
