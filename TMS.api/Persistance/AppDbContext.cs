using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TMS.api.Entities;
using TMS.api.Persistance.EntityConfigs;

namespace TMS.api.Persistance
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskItemConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
