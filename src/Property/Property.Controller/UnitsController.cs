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
    [Route("api/units")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitCommands _unitCommands;
        private readonly IUnitQueries _unitQueries;

        public UnitsController(IUnitCommands unitCommands, IUnitQueries unitQueries)
        {
            _unitCommands = unitCommands;
            _unitQueries = unitQueries;
        }

        [HttpGet()]
        public async Task<ActionResult<List<UnitResponse>>> GetListOfUnit([FromQuery] string searchText = "")
        {
            var listOfUnit = await _unitQueries.GetListOfUnitResponseAsync();
            return Ok(listOfUnit);
        }

        [HttpGet("{unitId}")]
        public async Task<ActionResult<UnitResponse>> GetUnitById(Guid unitId)
        {
            var unitResponse = await _unitQueries.GetUnitResponseByIdAsync(unitId);
            if (unitResponse is null)
                return NotFound();

            return Ok(unitResponse);
        }

        [HttpPost("create")]
        public async Task<ActionResult<UnitResponse>> CreateUnit([FromBody] CreateUnitRequest request)
        {
            var response =
                await _unitCommands.CreateUnitAsync(request.BuildingId, request.Number, request.Floor,request.AreaSqm, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpDelete("{unitId}")]
        public async Task<ActionResult> DeleteUnit(Guid unitId)
        {
            Result result = await _unitCommands.DeleteUnitAsync(unitId, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }

        [HttpPut("{unitId}")]
        public async Task<ActionResult> UpdateUnit(Guid unitId, [FromQuery] int number, [FromQuery] int floor, [FromQuery] int areaSqm)
        {
            Result result = await _unitCommands.UpdateUnitAsync(unitId, number,floor,areaSqm, HttpContext.RequestAborted);

            if (result.HasError<EntityNotFoundError>(out var errors))
                return NotFound(errors.FirstOrDefault()?.Message);

            return Ok();
        }


    }
}
