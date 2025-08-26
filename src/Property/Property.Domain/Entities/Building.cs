using ApartmentManagementSystem.SharedKernel.Entitites;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class Building
    {
        public BuildingId Id { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int FloorCount { get; set; }
        public List<Apartment> Apartments { get; set; } = [];

        protected Building() { }

        // Private constructor
        private Building(BuildingId id, string name, string address, int floorCount)
        {
            Id = id;
            Name = name;
            Address = address;
            FloorCount = floorCount;
        }


        // Factory method to create a Building
        public static Building Create(string name, string address, int floorCount)
        {
            var building = new Building(id: new BuildingId(Guid.NewGuid()), name: name, address: address, floorCount: floorCount);
            return building;
        }

        public void Update(string name, string address, int floorCount)
        {
            Name = name;
            Address = address;
            FloorCount = floorCount;
        }

        public void AddApartment(Apartment apartment)
        {
            Apartments.Add(apartment);
        }
    }
}
