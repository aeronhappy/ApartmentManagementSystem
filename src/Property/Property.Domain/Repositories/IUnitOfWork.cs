namespace Property.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IBuildingRepository Buildings { get; }
        IApartmentRepository Apartments { get; }
        IOwnerRepository Owners { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
