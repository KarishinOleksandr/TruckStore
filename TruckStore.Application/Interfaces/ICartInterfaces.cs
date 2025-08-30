using TruckStore.Domain.Cart;

namespace TruckStore.Application.Interfaces
{
    public interface ICartInterfaces
    {
        Task<CartItem?> GetItemAsync(Guid cartId, Guid truckId);
        Task AdditemAsync(CartItem item);
        Task<List<CartItem>> GetAllItemAsync(Guid cartId);
        Task Save();
    }
}
