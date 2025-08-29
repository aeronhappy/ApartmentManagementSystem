using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface IInvoiceCommands
    {
        Task<Result> CreatePaymentInvoice(Guid InvoiceId);

    }
}
