using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastracture.Data.Configuration
{
    public class LeaseAgreementConfiguration : IEntityTypeConfiguration<LeaseAgreement>
    {
        public void Configure(EntityTypeBuilder<LeaseAgreement> leaseAgreement)
        {

            leaseAgreement.HasKey(o => o.Id);
            leaseAgreement.Property(o => o.Id)
                .HasConversion(
                    o => o.Value,
                    value => new LeaseAgreementId(value));
          

        }
    }
}
