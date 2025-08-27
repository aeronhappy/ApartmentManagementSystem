using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using MediatR;
using Property.IntegrationEvent;

namespace Leasing.Application.EventHandler.Integration
{


    public class ApartmentCreatedIntegrationEventHandler : INotificationHandler<ApartmentCreatedIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApartmentCreatedIntegrationEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ApartmentCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {

            if (notification == null)
                return;

            Apartment apartment = new()
            {
                Id = new ApartmentId(notification.ApplicationId),
                BuildingId = notification.BuildingId,
                BuildingName = notification.BuildingName,
                Name = notification.Name,
                Number = notification.Number,
                Floor = notification.Floor,
                AreaSqm = notification.AreaSqm,
                Status = notification.Status
            };


            await _unitOfWork.Apartments.AddApartmentAsync(apartment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
