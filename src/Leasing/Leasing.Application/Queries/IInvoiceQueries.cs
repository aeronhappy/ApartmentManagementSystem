using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface IInvoiceQueries
    {
        Task<List<InvoiceResponse>> GetListOfInvoiceResponseAsync();
        Task<InvoiceResponse?> GetInvoiceResponseByIdAsync(Guid id);
        Task<List<InvoiceResponse>> GetListOfInvoiceResponseByApartmentAsync(Guid apartmentId);
        Task<List<InvoiceResponse>> GetListOfInvoiceResponseByTenantAsync(Guid tenantId);

    }
}
