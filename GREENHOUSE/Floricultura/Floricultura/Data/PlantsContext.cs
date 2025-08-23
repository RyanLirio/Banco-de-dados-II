using Floricultura.Models;
using Microsoft.EntityFrameworkCore;

namespace Floricultura.Data
{
    public class PlantsContext(DbContextOptions<PlantsContext> options) : DbContext(options)
    {

        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().ToTable("Plant");
        }
    }
}
