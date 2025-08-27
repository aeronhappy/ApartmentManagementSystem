using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Repositories
{
    public interface ILeasingRepository
    {
        Task<LeaseAgreement?> GetLeaseAgreementByIdAsync(LeaseAgreementId id);
        Task AddLeaseAgreementAsync(LeaseAgreement leaseAgreement);
        Task DeleteLeaseAgreementAsync(LeaseAgreementId id);
    }
}
