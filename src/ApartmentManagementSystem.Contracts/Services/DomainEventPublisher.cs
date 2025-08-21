using ApartmentManagementSystem.SharedKernel;
using MediatR;

namespace ApartmentManagementSystem.Contracts.Services
{
    public class DomainEventPublisher : IDomainEventPublisher
    {
        private readonly IPublisher _publisher;

        public DomainEventPublisher(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task PublishAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
