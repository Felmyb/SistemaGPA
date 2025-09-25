using Microsoft.EntityFrameworkCore;

namespace AgilePM.API.Models
{
    public class AgilePmDbContext : DbContext
    {
        public AgilePmDbContext(DbContextOptions<AgilePmDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Sprint> Sprints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relaciones y restricciones personalizadas aquí si es necesario
        }
    }
}