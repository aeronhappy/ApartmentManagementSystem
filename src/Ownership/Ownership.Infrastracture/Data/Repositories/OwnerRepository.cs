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
            return await _context.Owners.FindAsync(id);
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

      
    }
}
