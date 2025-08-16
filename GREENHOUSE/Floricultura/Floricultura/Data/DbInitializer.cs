using Floricultura.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Metrics;
namespace Floricultura.Data
{
    public static class DbInitializer
    {
        public async static void Initialize(PlantsContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (await context.Database.EnsureDeletedAsync())
                return;

            var plants = new Plant[]
            {
                new(){Nome="Lirio", Humidade=23}
            };

            foreach (Plant p in plants) 
            { 
                await context.Plants.AddAsync(p); 
            }
            context.SaveChanges();
        }
    }
}
