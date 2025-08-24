using ApartmentManagementSystem.SharedKernel.Enum;

namespace Leasing.Controller.Request
{
    public class CreateLeaseAgreementRequest
    {
        public Guid TenantId { get; set; }
        public Guid UnitId { get; set; }
        public required int MonthlyRent { get; set; }
        public LeaseTerm LeaseTermInMonths { get; set; }
        public DateTime DateStart { get; set; }
    }
}
