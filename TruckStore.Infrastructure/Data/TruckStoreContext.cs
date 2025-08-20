using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;
using TruckStore.Domain.Trucks;

namespace TruckStore.Infrastructure.Data
{
    public class TruckStoreContext(DbContextOptions<TruckStoreContext> options) : DbContext(options)
    {
        public DbSet<Truck> Trucks => Set<Truck>();
        public DbSet<Brand> Brands => Set<Brand>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new { Id = 1, Name = "Mercedes" },
                new { Id = 2, Name = "Volvo" },
                new { Id = 3, Name = "Renault" },
                new { Id = 4, Name = "Scania" },
                new { Id = 5, Name = "Iveco" }
            );
        }
    }
}
