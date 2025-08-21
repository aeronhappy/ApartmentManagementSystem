using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly PropertyDbContext _context;

        public UnitRepository(PropertyDbContext context)
        {
            _context = context;
        }

        public async Task<Unit?> GetUnitByIdAsync(UnitId id)
        {
            return await _context.Units.FindAsync(id);
        }

        public async Task AddUnitAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
        }

        public async Task DeleteUnitAsync(UnitId id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit is null)
                return;

            _context.Units.Remove(unit);
        }

      
       

      


    }
}
