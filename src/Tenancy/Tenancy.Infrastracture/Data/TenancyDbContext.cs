using Microsoft.EntityFrameworkCore;
using Tenancy.Domain.Entities;

namespace Tenancy.Infrastracture.Data
{
    public class TenancyDbContext : DbContext
    {
        public TenancyDbContext(DbContextOptions<TenancyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Tenancy");
            modelBuilder
              .ApplyConfigurationsFromAssembly(typeof(TenancyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
    }
}
