using Core.Features.Employee;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence
{
    public class BackEndContext:DbContext
    {
        public BackEndContext(DbContextOptions<BackEndContext> options):base(options)
        {
            
        }

        public DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
