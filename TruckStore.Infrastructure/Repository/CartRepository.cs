using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Cart;
using TruckStore.Infrastructure.Data;

namespace TruckStore.Infrastructure.Repository
{
    public class CartRepository : ICartInterfaces
    {
        private readonly TruckStoreContext _context;

        public CartRepository(TruckStoreContext context)
        {
            _context = context;
        }

        public async Task AdditemAsync(CartItem item)
        {
            await _context.AddAsync(item);
        }

        public async Task<List<CartItem>> GetAllItemAsync(Guid cartId)
        {
            return await _context.CartItems.Where(c => c.CartId == cartId).Include(c => c.Truck).ToListAsync();

        }

        public async Task<CartItem?> GetItemAsync(Guid cartId, Guid truckId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(c => c.CartId == cartId && c.TruckId == truckId);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
