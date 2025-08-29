using ApartmentManagementSystem.SharedKernel.Enum;
using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface IPaymentReceiptCommands
    {
        Task<Result<PaymentReceiptResponse>> AddPaymentReceiptAsync(Guid invoiceId,Guid tenantId,PaymentMethod paymentMethod, CancellationToken cancellationToken);
    }
}
