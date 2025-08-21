
namespace Ownership.Application.Response
{
    public class BuildingResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int FloorCount { get; set; }
        public List<UnitResponseWithoutBuilding> Unit { get; set; } = [];
    }


    public class BuildingResponseWithoutUnits
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int FloorCount { get; set; }
    }
}
