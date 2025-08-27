using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;
using TruckStore.Domain.Cart;
using TruckStore.Domain.Trucks;

namespace TruckStore.Infrastructure.Data
{
    public class TruckStoreContext(DbContextOptions<TruckStoreContext> options) : DbContext(options)
    {
        public DbSet<Truck> Trucks => Set<Truck>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(BrandsBaseData.BrandsData);
        }
    }
}
