using Floricultura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Floricultura.Data
{
    public class PlantsContextFactory : IDesignTimeDbContextFactory<PlantsContext>
    {
        public PlantsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PlantsContext>();

            // Usa a mesma connection string do appsettings.json
            optionsBuilder.UseSqlServer("Server=localhost;Database=FloriculturaDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new PlantsContext(optionsBuilder.Options);
        }
    }
}
