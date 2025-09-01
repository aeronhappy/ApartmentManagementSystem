using Ownership.Domain.Entities;
using Ownership.Domain.Repositories;
using Ownership.Domain.ValueObjects;

namespace Ownership.Infrastracture.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly OwnershipDbContext _context;

        public ApartmentRepository(OwnershipDbContext context)
        {
            _context = context;
        }

        public async Task<Apartment?> GetApartmentByIdAsync(ApartmentId id)
        {
            return await _context.Apartments.FindAsync(id);
        }

        public async Task AddApartmentAsync(Apartment apartment)
        {
            await _context.Apartments.AddAsync(apartment);
        }

        public async Task DeleteApartmentAsync(ApartmentId id)
        {
            var unit = await _context.Apartments.FindAsync(id);

            if (unit is null)
                return;

            _context.Apartments.Remove(unit);
        }

    }
}
