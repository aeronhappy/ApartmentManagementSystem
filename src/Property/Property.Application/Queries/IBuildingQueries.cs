using Property.Application.Response;

namespace Property.Application.Queries
{
    public interface IBuildingQueries
    {
        Task<List<BuildingResponse>> GetListOfBuildingResponseAsync();
        Task<BuildingResponse?> GetBuildingResponseByIdAsync(Guid id);
    }
}
