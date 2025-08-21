using FluentResults;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Application.Commands
{
    public interface IUnitCommands
    {
        Task<Result<UnitResponse>> CreateUnitAsync(Guid buildingId, int number, int floor,int areaSqm, CancellationToken cancellationToken);
        Task<Result> DeleteUnitAsync(Guid unitId, CancellationToken cancellationToken);
        Task<Result> UpdateUnitAsync(Guid unitId, int number, int floor, int areaSqm, CancellationToken cancellationToken);
    }
}
