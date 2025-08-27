using ApartmentManagementSystem.SharedKernel.Enum;
using FluentResults;
using Property.Application.Response;
using Property.Domain.Entities;

namespace Property.Application.Commands
{
    public interface IApartmentCommands
    {
        Task<Result<ApartmentResponse>> CreateApartmentAsync(Guid buildingId, int number, int floor, int areaSqm, CancellationToken cancellationToken);
        Task<Result> DeleteApartmentAsync(Guid apartmentId, CancellationToken cancellationToken);
        Task<Result> UpdateApartmentAsync(Guid apartmentId, int number, int floor, int areaSqm, CancellationToken cancellationToken);
        Task<Result> AssignOwnerAsync(Guid apartmentId, Guid ownerId, CancellationToken cancellationToken);
        Task<Result> AddLeaseAgreementAsync(Guid apartmentId, LeaseAgreement leaseAgreement, CancellationToken cancellationToken);
        Task<Result> ChangeStatusAsync(Guid apartmentId,ApartmentStatus apartmentStatus , CancellationToken cancellationToken);
    }
}

