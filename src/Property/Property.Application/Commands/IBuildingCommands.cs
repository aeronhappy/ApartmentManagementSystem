using FluentResults;
using Property.Application.Response;

namespace Property.Application.Commands
{
    public interface IBuildingCommands
    {

        Task<Result<BuildingResponse>> AddBuildingAsync(string name,string address,int floorCount, CancellationToken cancellationToken);
        Task<Result> DeleteBuildingAsync(Guid buildingId, CancellationToken cancellationToken);
        Task<Result> UpdateBuildingAsync(Guid buildingId,string name,string address,int floorCount, CancellationToken cancellationToken);

    }
}
