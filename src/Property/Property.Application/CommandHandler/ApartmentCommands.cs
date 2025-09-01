using ApartmentManagementSystem.SharedKernel.Enum;
using ApartmentManagementSystem.SharedKernel.Errors;
using ApartmentManagementSystem.Contracts.Services;
using AutoMapper;
using FluentResults;
using Property.Application.Commands;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandler
{
    public class ApartmentCommands : IApartmentCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainEventPublisher _domainEventPublisher;

        public ApartmentCommands(IUnitOfWork unitOfWork, IMapper mapper, IDomainEventPublisher domainEventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainEventPublisher = domainEventPublisher;
        }


        public async Task<Result<ApartmentResponse>> CreateApartmentAsync(Guid buildingId, int number, int floor, int areaSqm, CancellationToken cancellationToken)
        {
            Building? building = await _unitOfWork.Buildings.GetBuildingByIdAsync(new BuildingId(buildingId));

            if (building == null)
                return Result.Fail(new EntityNotFoundError($"No Building = {buildingId} found"));


            var apartment = Apartment.Create(building, number, floor, areaSqm);
            var apartmentResponse = _mapper.Map<ApartmentResponse>(apartment);

            building.AddApartment(apartment);
            await _unitOfWork.Apartments.AddApartmentAsync(apartment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _domainEventPublisher.PublishAsync(apartment.DomainEvents, default);

            return Result.Ok(apartmentResponse);
        }



        public async Task<Result> DeleteApartmentAsync(Guid apartmentId, CancellationToken cancellationToken)
        {
            Apartment? apartment = await _unitOfWork.Apartments.GetApartmentByIdAsync(new ApartmentId(apartmentId));

            if (apartment is null)
                return Result.Fail(new EntityNotFoundError($"No Apartment = {apartmentId} found"));

            await _unitOfWork.Apartments.DeleteApartmentAsync(new ApartmentId(apartmentId));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }


        public async Task<Result> UpdateApartmentAsync(Guid apartmentId, int number, int floor, int areaSqm, CancellationToken cancellationToken)
        {
            Apartment? unit = await _unitOfWork.Apartments.GetApartmentByIdAsync(new ApartmentId(apartmentId));

            if (unit is null)
                return Result.Fail(new EntityNotFoundError($"No Apartment = {apartmentId} found"));

            unit.Update(number, floor, areaSqm);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> AssignOwnerAsync(Guid apartmentId, Guid ownerId, CancellationToken cancellationToken)
        {
            Apartment? apartment = await _unitOfWork.Apartments.GetApartmentByIdAsync(new ApartmentId(apartmentId));
            if (apartment is null)
                return Result.Fail(new EntityNotFoundError($"No Apartment = {apartmentId} found"));


            Owner? owner = await _unitOfWork.Owners.GetOwnerByIdAsync(new OwnerId(ownerId));
            if (owner is null)
                return Result.Fail(new EntityNotFoundError($"No Owner = {ownerId} found"));


            apartment.AssignOwner(apartment,owner.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _domainEventPublisher.PublishAsync(apartment.DomainEvents, default);
            return Result.Ok();
        }

        public async Task<Result> AddLeaseAgreementAsync(Guid apartmentId, LeaseAgreement leaseAgreement, CancellationToken cancellationToken)
        {
            Apartment? apartment = await _unitOfWork.Apartments.GetApartmentByIdAsync(new ApartmentId(apartmentId));
            if (apartment is null)
                return Result.Fail(new EntityNotFoundError($"No Apartment = {apartmentId} found"));

            apartment.AddLeaseAgreement(leaseAgreement);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> ChangeStatusAsync(Guid apartmentId, ApartmentStatus apartmentStatus, CancellationToken cancellationToken)
        {
            Apartment? apartment = await _unitOfWork.Apartments.GetApartmentByIdAsync(new ApartmentId(apartmentId));
            if (apartment is null)
                return Result.Fail(new EntityNotFoundError($"No Apartment = {apartmentId} found"));

            apartment.ChangeStatus(apartmentStatus);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();

        }
    }
}
