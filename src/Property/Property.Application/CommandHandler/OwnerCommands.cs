using ApartmentManagementSystem.SharedKernel.Errors;
using AutoMapper;
using FluentResults;
using Property.Application.Commands;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Application.CommandHandler
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OwnerCommands(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Result<OwnerResponse>> AddOwnerAsync(Guid id, string email, string name, string address, string contactNumber, CancellationToken cancellationToken)
        {
            var owner = Owner.Create(id,email,name, address, contactNumber);
            var ownerResponse = _mapper.Map<OwnerResponse>(owner);
            await _unitOfWork.Owners.AddOwnerAsync(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok(ownerResponse);
        }

        public async Task<Result> AddUnitToOwner(Guid ownerId, Guid unitId, CancellationToken cancellationToken)
        {
            Owner? owner = await _unitOfWork.Owners.GetOwnerByIdAsync(new OwnerId(ownerId));

            if (owner is null)
                return Result.Fail(new EntityNotFoundError($"No Owner = {ownerId} found"));

            //owner.AddUnitToOwner(Unit)
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> DeleteOwnerAsync(Guid ownerId, CancellationToken cancellationToken)
        {
            Owner? owner = await _unitOfWork.Owners.GetOwnerByIdAsync(new OwnerId(ownerId));

            if (owner is null)
                return Result.Fail(new EntityNotFoundError($"No Owner = {ownerId} found"));

            await _unitOfWork.Owners.DeleteOwnerAsync(new OwnerId(ownerId));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> UpdateOwnerAsync(Guid ownerId, string name, string address, string contactNumber, CancellationToken cancellationToken)
        {
            Owner? owner = await _unitOfWork.Owners.GetOwnerByIdAsync(new OwnerId(ownerId));

            if (owner is null)
                return Result.Fail(new EntityNotFoundError($"No Owner = {ownerId} found"));

            owner.Update(name, address, contactNumber); 
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
