using Core.Features.Employee;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence
{
    public class BackEndContext:DbContext
    {
        public BackEndContext(DbContextOptions<BackEndContext> options):base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<EmployeeEntity>()
                .HasData(
                new EmployeeEntity { Id = 1, Name = "Francisco", LastName = "Garcia",CreatedDate=DateTime.Now },
                new EmployeeEntity { Id = 2, Name = "Laura", LastName  = "Feldmann", CreatedDate = DateTime.Now }
                );
        }
    }
}
