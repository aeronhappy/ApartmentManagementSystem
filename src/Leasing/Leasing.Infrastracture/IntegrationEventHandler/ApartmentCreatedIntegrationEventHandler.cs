using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Leasing.Infrastracture.Data;
using MediatR;
using Property.IntegrationEvent;

namespace Leasing.Infrastracture.IntegrationEventHandler
{


    public class ApartmentCreatedIntegrationEventHandler : INotificationHandler<ApartmentCreatedIntegrationEvent>
    {
        private readonly LeasingDbContext _context;

        public ApartmentCreatedIntegrationEventHandler(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ApartmentCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {

            if (notification?.Apartment == null)
                return;

            Apartment apartment = new()
            {
                Id = new ApartmentId(notification.Apartment.Id.Value),
                BuildingId = notification.Apartment.BuildingId.Value,
                BuildingName = notification.Apartment.Building.Name,
                Number = notification.Apartment.Number,
                Floor = notification.Apartment.Floor,
                AreaSqm = notification.Apartment.AreaSqm,
                Status = notification.Apartment.Status,
                OwnerId = notification.Apartment.OwnerId!.Value,
                OwnerName = notification.Apartment.Owner!.Name

            };

            await _context.Apartments.AddAsync(apartment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
