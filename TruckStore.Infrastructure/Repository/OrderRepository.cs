using TruckStore.Application.Interfaces;
using TruckStore.Domain.Cart;
using TruckStore.Infrastructure.Data;

namespace TruckStore.Infrastructure.Repository
{
    public class OrderRepository : IOrderInterface
    {
        private readonly TruckStoreContext _context;

        public OrderRepository(TruckStoreContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Order order, List<CartItem> items)
        {
            await _context.Orders.AddAsync(order);

            foreach(var item in items)
            {
                var detail = new OrderDetails()
                {
                    TruckId = item.Truck.Id,
                    OrderId = order.Id,
                    Price = item.Truck.Price
                };

                await _context.OrderDetails.AddAsync(detail);
            }

            await _context.SaveChangesAsync();
        }
    }
}
