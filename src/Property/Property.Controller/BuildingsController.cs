using ApartmentManagementSystem.SharedKernel.Errors;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Commands;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Controller.Request;

namespace Property.Controller
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingCommands _buildingCommand;
        private readonly IBuildingQueries _buildingQueries;

        public BuildingsController(IBuildingCommands buildingCommand, IBuildingQueries buildingQueries)
        {
            _buildingCommand = buildingCommand;
            _buildingQueries = buildingQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<BuildingResponse>>> GetListOfBuilding([FromQuery] string searchText = "")
        {
            var listOfBuilding = await _buildingQueries.GetListOfBuildingResponseAsync();
            return Ok(listOfBuilding);
        }

        [HttpGet("{buildingId}")]
        public async Task<ActionResult<BuildingResponse>> GetBuildingById(Guid buildingId)
        {
            var buildingResponse = await _buildingQueries.GetBuildingResponseByIdAsync(buildingId);
            if (buildingResponse is null)
                return NotFound();

            return Ok(buildingResponse);
        }

        [HttpPost("create")]
        public async Task<ActionResult<BuildingResponse>> CreateBuilding([FromBody] CreateBuildingRequest request)
        {
            var response =
                await _buildingCommand.AddBuildingAsync(request.Name, request.Address, request.FloorCount, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpDelete("{buildingId}")]
        public async Task<ActionResult> DeleteBuidling(Guid buildingId)
        {
            Result result = await _buildingCommand.DeleteBuildingAsync(buildingId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPut("{buildingId}")]
        public async Task<ActionResult> UpdateBuilding(Guid buildingId, [FromQuery] string name, [FromQuery] string address, [FromQuery] int floorCount)
        {
            Result result = await _buildingCommand.UpdateBuildingAsync(buildingId,name,address,floorCount, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }


    }
}
