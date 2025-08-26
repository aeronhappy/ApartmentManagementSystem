namespace Leasing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITenantRepository Tenants { get; }
        ILeasingRepository Leasings { get; }
        IApartmentRepository Apartments { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
