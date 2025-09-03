using Property.Application.Response;

namespace Property.Application.Queries
{
    public interface IApartmentQueries
    {

        Task<ApartmentResponse?> GetApartmentResponseByIdAsync(Guid id);
        Task<List<ApartmentResponse>> GetListOfApartmentResponseAsync(string searchText);
        Task<List<ApartmentResponse>> GetListOfApartmentResponseByBuildingAsync(string searchText, Guid buildingId);
    }
}
