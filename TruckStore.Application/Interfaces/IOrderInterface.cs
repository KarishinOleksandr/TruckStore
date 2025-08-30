using TruckStore.Domain.Cart;

namespace TruckStore.Application.Interfaces
{
    public interface IOrderInterface
    {
        Task CreateOrder(Order order, List<CartItem> items);
    }
}
