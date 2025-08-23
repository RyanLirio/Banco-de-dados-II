using Floricultura.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Metrics;
namespace Floricultura.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PlantsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Plants.Any())
                return;

            var plants = new Plant[]
            {
                new(){Nome="Lirio", Humidade=23}
            };

            foreach (Plant p in plants) 
            { 
                context.Plants.Add(p); 
            }
            context.SaveChanges();
        }
    }
}
