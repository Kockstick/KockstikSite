using KockstikSite.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace KockstikSite.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public AppDbContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
