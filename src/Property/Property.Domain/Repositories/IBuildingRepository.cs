using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Repositories
{
    public interface IBuildingRepository
    {
        Task<Building?> GetBuildingByIdAsync(BuildingId id);
        Task AddBuildingAsync(Building building);
        Task DeleteBuildingAsync(BuildingId id);
    }
}
