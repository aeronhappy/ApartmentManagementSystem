using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly PropertyDbContext _context;

        public BuildingRepository(PropertyDbContext context)
        {
            _context = context;
        }


        public async Task<Building?> GetBuildingByIdAsync(BuildingId id)
        {
            return await _context.Buildings
                 .Include(b => b.Apartments)
                 .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBuildingAsync(Building building)
        {
            await _context.Buildings.AddAsync(building);
        }


        public async Task DeleteBuildingAsync(BuildingId id)
        {
            var building = await _context.Buildings.FindAsync(id);

            if (building is null)
                return;

            _context.Buildings.Remove(building);

        }



      



    }
}
