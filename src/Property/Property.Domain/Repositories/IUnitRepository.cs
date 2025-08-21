using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Repositories
{
    public interface IUnitRepository
    {
        Task<Unit?> GetUnitByIdAsync(UnitId id);
        Task AddUnitAsync(Unit unit);
        Task DeleteUnitAsync(UnitId id);
    }
}
