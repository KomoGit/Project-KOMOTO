using Microsoft.EntityFrameworkCore;
using TestingApplication.Model;

namespace TestingApplication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
