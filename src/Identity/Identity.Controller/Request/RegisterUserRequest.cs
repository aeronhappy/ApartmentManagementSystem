using System.ComponentModel.DataAnnotations;

namespace Identity.Controller.Request
{
    public class RegisterUserRequest
    {
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int Gender { get; set; }
        public required int ContactNumber { get; set; }
        //public required string ValidIdType { get; set; }
        //public required string ValidIdNumber { get; set; }
        public List<Guid> RolesId { get; set; } = [];
    }
}
