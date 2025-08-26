using Property.Application.Response;

namespace Property.Application.Queries
{
    public interface IApartmentQueries
    {
        Task<List<ApartmentResponse>> GetListOfApartmentResponseAsync();
        Task<ApartmentResponse?> GetApartmentResponseByIdAsync(Guid id);
    }
}
