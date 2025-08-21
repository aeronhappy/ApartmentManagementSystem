
namespace Property.Controller.Request
{
    public class CreateBuildingRequest
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int FloorCount  { get; set; }
    }
}
