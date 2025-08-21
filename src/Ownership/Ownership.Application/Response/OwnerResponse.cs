using Property.Application.Response;

namespace Ownership.Application.Response
{
    public class OwnerResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int ContactNumber { get; set; }
        public List<UnitResponseWithoutBuilding> Unit { get; set; } = [];
    }


}
