using Property.Application.Response;

namespace Property.Application.Queries
{
    public interface IUnitQueries
    {
        Task<List<UnitResponse>> GetListOfUnitResponseAsync();
        Task<UnitResponse?> GetUnitResponseByIdAsync(Guid id);
    }
}
