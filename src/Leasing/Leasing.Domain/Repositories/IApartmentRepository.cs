using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetApartmentByIdAsync(ApartmentId id);
        Task AddApartmentAsync(Apartment apartment);
        Task DeleteApartmentAsync(ApartmentId id);
    }
}
