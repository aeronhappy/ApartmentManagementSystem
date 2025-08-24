using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;

namespace Property.Infrastracture.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Property");
            modelBuilder
              .ApplyConfigurationsFromAssembly(typeof(PropertyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
