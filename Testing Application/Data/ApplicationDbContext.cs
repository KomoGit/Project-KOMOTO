using Microsoft.EntityFrameworkCore;
using TestingApplication.Model;

namespace TestingApplication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Job> ArchivedJobs { get; set; }
        public DbSet<Job> ScheduledJobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        //public DbSet<Tool> Tools { get; set; }
    }
}
