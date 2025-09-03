using Microsoft.EntityFrameworkCore;
using Ownership.Domain.Entities;
using Ownership.Domain.Repositories;
using Ownership.Domain.ValueObjects;

namespace Ownership.Infrastracture.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly OwnershipDbContext _context;

        public OwnerRepository(OwnershipDbContext context)
        {
            _context = context;
        }

        public async Task<Owner?> GetOwnerByIdAsync(OwnerId id)
        {
            return await _context.Owners
              .Include(a => a.Apartments)
              .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddOwnerAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public async Task AddUnitToOwnerAsync(OwnerId id, Apartment apartment)
        {
            Owner? owner = await _context.Owners.FindAsync(id);
            if(owner is null)
                return;

            owner.Apartments.Add(apartment);
        }

        public async Task DeleteOwnerAsync(OwnerId id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner is null)
                return;

            _context.Owners.Remove(owner);
        }



        public async Task RemoveOwnerToUnitAsync(ApartmentId apartmentId, OwnerId ownerId)
        {
            var owner = await _context.Owners
             .Include(a => a.Apartments)
             .FirstOrDefaultAsync(i => i.Id == ownerId);

            if(owner is null)
                return;

            var apartment = owner.Apartments.FirstOrDefault(a => a.Id == apartmentId);
            if (apartment is null)
                return;
            owner.Apartments.Remove(apartment!);
        }
    }
}
