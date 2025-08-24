using Property.Application.Response;

namespace Property.Application.Queries
{
    public interface IOwnerQueries
    {
        Task<List<OwnerResponse>> GetListOfOwnerResponseAsync();
        Task<OwnerResponse?> GetOwnerResponseByIdAsync(Guid id);
    }
}
