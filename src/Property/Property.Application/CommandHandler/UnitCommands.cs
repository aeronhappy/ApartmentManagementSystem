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
    public class UnitCommands : IUnitCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<UnitResponse>> CreateUnitAsync(Guid buildingId, int number, int floor, int areaSqm, CancellationToken cancellationToken)
        {
            Building? building = await _unitOfWork.Buildings.GetBuildingByIdAsync(new BuildingId(buildingId));

            if (building == null)
                return Result.Fail(new EntityNotFoundError($"No Building = {buildingId} found"));


            var unit = Unit.Create(building, number, floor, areaSqm);
            var unitResponse = _mapper.Map<UnitResponse>(unit);

            building.AddUnit(unit);
            await _unitOfWork.Units.AddUnitAsync(unit);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok(unitResponse);
        }

        public async Task<Result> DeleteUnitAsync(Guid unitId, CancellationToken cancellationToken)
        {
            Unit? unit = await _unitOfWork.Units.GetUnitByIdAsync(new UnitId(unitId));

            if (unit is null)
                return Result.Fail(new EntityNotFoundError($"No Unit = {unitId} found"));

            await _unitOfWork.Units.DeleteUnitAsync(new UnitId(unitId));
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> UpdateUnitAsync(Guid unitId, int number, int floor, int areaSqm, CancellationToken cancellationToken)
        {
            Unit? unit = await _unitOfWork.Units.GetUnitByIdAsync(new UnitId(unitId));

            if (unit is null)
                return Result.Fail(new EntityNotFoundError($"No Unit = {unitId} found"));

            unit.Update( number,  floor,  areaSqm);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
