using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface IInvoiceQueries
    {
        Task<List<InvoiceResponse>> GetListOfInvoiceResponseAsync(string searchText);
        Task<InvoiceResponse?> GetInvoiceResponseByIdAsync(Guid id);
        Task<List<InvoiceResponse>> GetListOfInvoiceResponseByApartmentAsync(Guid apartmentId, string searchText);
        Task<List<InvoiceResponse>> GetListOfInvoiceResponseByTenantAsync(Guid tenantId, string searchText);

    }
}
