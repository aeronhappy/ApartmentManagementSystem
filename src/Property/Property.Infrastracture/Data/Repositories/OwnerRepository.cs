using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PropertyDbContext _context;

        public OwnerRepository(PropertyDbContext context)
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

        public async Task DeleteOwnerAsync(OwnerId id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner is null)
                return;

            _context.Owners.Remove(owner);
        }

    }
}
