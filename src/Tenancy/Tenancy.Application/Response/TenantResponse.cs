namespace Tenancy.Application.Response
{
    public class TenantResponse
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int Gender { get; set; }
        public required string ContactNumber { get; set; }
        public LeaseAgreementResponse? LeaseAgreement { get; set; }

    }



}
