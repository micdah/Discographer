using Microsoft.EntityFrameworkCore;
using Discographer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace Discographer.Domain
{
    public class DiscographerContext : DbContext
    {
        public DiscographerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationSettings> ApplicationSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationSettingsConfiguration());
        }
    }

    public class DeisngTimeDbContextFacotyr : IDesignTimeDbContextFactory<DiscographerContext>
    {
        public DiscographerContext CreateDbContext(string[] args)
        {
            return new DiscographerContext(
                new DbContextOptionsBuilder()
                .UseSqlite("Data Source=Migrations.db")
                .Options);
        }
    }
}
