using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetApartmentByIdAsync(ApartmentId id);
        Task AddApartmentAsync(Apartment apartment);
    }
}
