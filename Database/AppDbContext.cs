using KockstikSite.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KockstikSite.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=db_fermermarket;UID=postgres;PWD=admin");
        }
    }
}
