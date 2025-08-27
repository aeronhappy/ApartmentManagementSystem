using FluentResults;
using Property.Application.Response;

namespace Property.Application.Commands
{
    public interface IOwnerCommands
    {

        Task<Result<OwnerResponse>> AddOwnerAsync(Guid id ,string email, string name, string address, string contactNumber, CancellationToken cancellationToken);
        Task<Result> DeleteOwnerAsync(Guid ownerId, CancellationToken cancellationToken);
        Task<Result> UpdateOwnerAsync(Guid ownerId, string name, string address, string contactNumber, CancellationToken cancellationToken);
      
    }
}
