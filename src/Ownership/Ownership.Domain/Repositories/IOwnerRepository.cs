using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<Owner?> GetOwnerByIdAsync(OwnerId id);
        Task AddOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(OwnerId id);
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
