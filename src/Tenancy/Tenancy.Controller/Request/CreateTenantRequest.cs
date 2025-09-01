using System.ComponentModel.DataAnnotations;

namespace Leasing.Controller.Request
{
    public class CreateTenantRequest
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public  int Gender { get; set; }
        public required string ContactNumber  { get; set; }
    }
}
