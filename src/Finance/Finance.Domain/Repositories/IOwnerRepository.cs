using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<Owner?> GetOwnerByIdAsync(OwnerId id);
        Task AddOwnerAsync(Owner owner);
        Task DeleteOwnerAsync(OwnerId id);
    }
}
