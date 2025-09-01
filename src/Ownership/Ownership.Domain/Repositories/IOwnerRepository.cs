using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<Owner?> GetOwnerByIdAsync(OwnerId id);
        Task AddOwnerAsync(Owner owner);
        Task AddUnitToOwnerAsync(OwnerId id, Apartment apartment);
        Task DeleteOwnerAsync(OwnerId id);
    }
}
