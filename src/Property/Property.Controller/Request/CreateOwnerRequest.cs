using System.ComponentModel.DataAnnotations;

namespace Property.Controller.Request
{
    public class CreateOwnerRequest
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string ContactNumber  { get; set; }
    }
}
