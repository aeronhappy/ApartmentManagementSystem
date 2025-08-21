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
    public class BuildingCommands : IBuildingCommands
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BuildingCommands( IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<BuildingResponse>> AddBuildingAsync(string name, string address, int floorCount, CancellationToken cancellationToken)
        {
            var building = Building.Create(name, address, floorCount);
            var buildingResponse = _mapper.Map<BuildingResponse>(building);
            await _unitOfWork.Buildings.AddBuildingAsync(building);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok(buildingResponse);
        }

        public async Task<Result> DeleteBuildingAsync(Guid buildingId, CancellationToken cancellationToken)
        {
            Building? building = await _unitOfWork.Buildings.GetBuildingByIdAsync(new BuildingId(buildingId));

            if (building is null)
                return Result.Fail(new EntityNotFoundError($"No Building = {buildingId} found"));

            await _unitOfWork.Buildings.DeleteBuildingAsync(new BuildingId(buildingId));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> UpdateBuildingAsync(Guid buildingId, string name, string address, int floorCount, CancellationToken cancellationToken)
        {
            Building? building = await _unitOfWork.Buildings.GetBuildingByIdAsync(new BuildingId(buildingId));

            if (building is null)
                return Result.Fail(new EntityNotFoundError($"No Building = {buildingId} found"));

            building.Update(name, address, floorCount);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();

        }
    }
}
