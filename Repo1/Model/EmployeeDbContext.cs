using Microsoft.EntityFrameworkCore;

namespace Repo1.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options):base (options)
        {
            
        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Student2> Students { get; set; }
    }
}
