using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly PropertyDbContext _context;

        public ApartmentRepository(PropertyDbContext context)
        {
            _context = context;
        }

        public async Task<Apartment?> GetApartmentByIdAsync(ApartmentId id)
        {
          
            return await _context.Apartments
            .Include(a=>a.Building)
            .FirstOrDefaultAsync(i => i.Id == id);
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
