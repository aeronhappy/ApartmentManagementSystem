namespace Property.Application.Response
{
    public class UnitResponse
    {
        public Guid Id { get; private set; }
        public BuildingResponseWithoutUnits Building { get; private set; } = null!;
        public string Number { get; private set; } = null!;
        public int Floor { get; private set; }
        public int AreaSqm { get; private set; }
    }

    public class UnitResponseWithoutBuilding
    {
        public Guid Id { get; private set; }
        public string Number { get; private set; } = null!;
        public int Floor { get; private set; }
        public int AreaSqm { get; private set; }
    }
}
