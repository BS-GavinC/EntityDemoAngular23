using EntityDemo.Models.Context.Configs;
using Microsoft.EntityFrameworkCore;

namespace EntityDemo.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Voiture> Voitures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost;Database=MyEntityDemoDatabase2;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigVoiture());
        }

    }
}
