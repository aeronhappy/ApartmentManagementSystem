namespace Tenancy.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITenantRepository Tenants { get; }
        ILeasingRepository Leasings { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
