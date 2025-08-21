using Ownership.Application.Response;

namespace Ownership.Application.Queries
{
    public interface IOwnerQueries
    {
        Task<List<OwnerResponse>> GetListOfOwnerResponseAsync();
        Task<OwnerResponse?> GetOwnerResponseByIdAsync(Guid id);
    }
}
