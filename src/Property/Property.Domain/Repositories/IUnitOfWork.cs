namespace Property.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IBuildingRepository Buildings { get; }
        IUnitRepository Units { get; }
        IOwnerRepository Owners { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
