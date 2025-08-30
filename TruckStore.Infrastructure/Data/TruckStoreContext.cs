using Microsoft.EntityFrameworkCore;
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
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetails> OrderDetails => Set<OrderDetails>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(BrandsBaseData.BrandsData);
        }
    }
}
