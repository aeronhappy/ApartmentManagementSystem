using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface IPaymentReceiptRepository
    {
        Task<PaymentReceipt?> GetPaymentReceiptByIdAsync(PaymentReceiptId id);
        Task AddPaymentReceiptAsync(PaymentReceipt paymentReceipt);
    }
}
