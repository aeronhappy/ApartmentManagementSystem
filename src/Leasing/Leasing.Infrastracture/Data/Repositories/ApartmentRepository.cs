using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Infrastracture.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly LeasingDbContext _context;

        public ApartmentRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task<Apartment?> GetApartmentByIdAsync(ApartmentId id)
        {
            return await _context.Apartments.FindAsync(id);
        }

    }
}
