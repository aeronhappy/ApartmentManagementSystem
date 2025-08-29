using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice?> GetInvoiceByIdAsync(InvoiceId id);
    }
}
