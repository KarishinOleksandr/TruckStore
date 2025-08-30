using TruckStore.Application.Interfaces;

namespace TruckStore.Infrastructure.Repository
{
    public sealed class CartContext : ICartContext
    {
        public Guid? CartId { get; set; }
    }
}
