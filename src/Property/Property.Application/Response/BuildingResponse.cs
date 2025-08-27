namespace Property.Application.Response
{
    public class BuildingResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int FloorCount { get; set; }
        public List<ApartmentResponseWithoutBuilding> Apartments { get; set; } = [];
    }


    public class BuildingResponseWithoutApartments
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int FloorCount { get; set; }
    }
}
