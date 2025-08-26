using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetApartmentByIdAsync(ApartmentId id);
        Task AddApartmentAsync(Apartment apartment);
        Task DeleteApartmentAsync(ApartmentId id);
    }
}
