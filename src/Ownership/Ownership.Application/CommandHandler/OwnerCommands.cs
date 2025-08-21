using ApartmentManagementSystem.SharedKernel.Errors;
using AutoMapper;
using FluentResults;
using Ownership.Application.Commands;
using Ownership.Application.Response;
using Ownership.Domain.Entities;
using Ownership.Domain.Repositories;
using Ownership.Domain.ValueObjects;

namespace Ownership.Application.CommandHandler
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerCommands(IOwnerRepository ownerRepository , IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }


        public async Task<Result<OwnerResponse>> AddOwnerAsync(string email, string name, string address, string contactNumber, CancellationToken cancellationToken)
        {
            var owner = Owner.Create(email,name, address, contactNumber);
            var ownerResponse = _mapper.Map<OwnerResponse>(owner);
            await _ownerRepository.AddOwnerAsync(owner);
            await _ownerRepository.SaveAsync(cancellationToken);
            return Result.Ok(ownerResponse);
        }


        public async Task<Result> DeleteOwnerAsync(Guid ownerId, CancellationToken cancellationToken)
        {
            Owner? owner = await _ownerRepository.GetOwnerByIdAsync(new OwnerId(ownerId));

            if (owner is null)
                return Result.Fail(new EntityNotFoundError($"No Owner = {ownerId} found"));

            await _ownerRepository.DeleteOwnerAsync(new OwnerId(ownerId));
            await _ownerRepository.SaveAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> UpdateOwnerAsync(Guid ownerId, string name, string address, string contactNumber, CancellationToken cancellationToken)
        {
            Owner? owner = await _ownerRepository.GetOwnerByIdAsync(new OwnerId(ownerId));

            if (owner is null)
                return Result.Fail(new EntityNotFoundError($"No Owner = {ownerId} found"));

            owner.Update(name, address, contactNumber);
            await _ownerRepository.SaveAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
