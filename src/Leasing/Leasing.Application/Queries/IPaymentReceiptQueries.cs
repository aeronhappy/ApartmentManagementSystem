using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface IPaymentReceiptQueries
    {
        Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseAsync();
        Task<PaymentReceiptResponse?> GetPaymentReceiptResponseByIdAsync(Guid id);
        Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByApartmentAsync(Guid apartmentId);
        Task<List<PaymentReceiptResponse>> GetListOfPaymentReceiptResponseByTenantAsync(Guid tenantId);

    }
}
