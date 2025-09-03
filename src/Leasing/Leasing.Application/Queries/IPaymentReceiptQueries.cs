using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface IPaymentReceiptQueries
    {
        Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseAsync(string searchText);
        Task<PaymentReceiptResponse?> GetPaymentReceiptResponseByIdAsync(Guid id);
        Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByApartmentAsync(Guid apartmentId, string searchText);
        Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByTenantAsync(Guid tenantId, string searchText);

    }
}
