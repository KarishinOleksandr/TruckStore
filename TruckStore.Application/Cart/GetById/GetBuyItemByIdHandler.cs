using MediatR;
using TruckStore.Application.Interfaces;

namespace TruckStore.Application.Cart.GetById
{
    public class GetBuyItemByIdHandler : IRequestHandler<GetBuyItemByIdQuery, Guid>
    {
        ICartIdProvider _cartIdProvider;

        public GetBuyItemByIdHandler(ICartIdProvider cartIdProvider)
        {
            _cartIdProvider = cartIdProvider;
        }

        public async Task<Guid> Handle(GetBuyItemByIdQuery request, CancellationToken cancellationToken)
        {
            var cartId = _cartIdProvider.GetCartId();
            if (cartId.HasValue) return cartId.Value;

            var newId = Guid.NewGuid();
            _cartIdProvider.SetCartId(newId);
            return newId;
        }
    }
}
