using Microsoft.EntityFrameworkCore;
using TMS.api.Entities;
using TMS.api.Persistance.EntityConfigs;

namespace TMS.api.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskItemConfig());
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
