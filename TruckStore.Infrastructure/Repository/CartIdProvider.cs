using TruckStore.Application.Interfaces;

namespace TruckStore.Infrastructure.Repository
{
    public class CartIdProvider : ICartIdProvider
    {
        private readonly ICartContext _context;

        public CartIdProvider(ICartContext context)
        {
            _context = context;
        }
        public Guid? GetCartId() => _context.CartId;

        public void SetCartId(Guid cartId) => _context.CartId = cartId;
    }
}
