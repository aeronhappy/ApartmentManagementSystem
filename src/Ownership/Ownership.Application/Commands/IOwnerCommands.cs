using FluentResults;
using Ownership.Application.Response;

namespace Ownership.Application.Commands
{
    public interface IOwnerCommands
    {

        Task<Result<OwnerResponse>> AddOwnerAsync(string email, string name, string address, string contactNumber, CancellationToken cancellationToken);
        Task<Result> DeleteOwnerAsync(Guid ownerId, CancellationToken cancellationToken);
        Task<Result> UpdateOwnerAsync(Guid ownerId, string name, string address, string contactNumber, CancellationToken cancellationToken);
        Task<Result> AddUnitToOwner(Guid ownerId, Guid unitId, CancellationToken cancellationToken);

    }
}
