namespace Leasing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITenantRepository Tenants { get; }
        ILeasingRepository Leasings { get; }
        IApartmentRepository Apartments { get; }
        IInvoiceRepository Invoices { get; }
        IPaymentReceiptRepository PaymentReceipts { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
