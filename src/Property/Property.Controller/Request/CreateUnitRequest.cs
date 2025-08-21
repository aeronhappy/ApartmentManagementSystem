

namespace Property.Controller.Request
{
    public class CreateUnitRequest
    {
        public Guid BuildingId { get; set; }
        public required int Number { get; set; }
        public required int Floor { get; set; }
        public required int AreaSqm { get; set; }
    }
}
