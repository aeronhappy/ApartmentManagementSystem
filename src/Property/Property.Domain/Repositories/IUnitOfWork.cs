namespace Property.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IBuildingRepository Buildings { get; }
        IUnitRepository Units { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
