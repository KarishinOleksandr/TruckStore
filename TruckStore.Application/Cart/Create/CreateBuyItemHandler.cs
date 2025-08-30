using MediatR;
using TruckStore.Application.Cart.GetById;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Cart;

namespace TruckStore.Application.Cart.Create
{
    public class CreateBuyItemHandler : IRequestHandler<CreateBuyItemCommand>
    {
        ICartInterfaces _ICartInterfaces;
        IMediator _mediator;

        public CreateBuyItemHandler(ICartInterfaces iCartInterfaces, IMediator mediator)
        {
            _ICartInterfaces = iCartInterfaces;
            _mediator = mediator;
        }

        public async Task Handle(CreateBuyItemCommand request, CancellationToken cancellationToken)
        {
            var cartId = await _mediator.Send(new GetBuyItemByIdQuery());

            var item = await _ICartInterfaces.GetItemAsync(cartId, request.TruckId);

            if(item == null)
            {
                item = new CartItem
                {
                    ItemId = request.ItemId,
                    CartId = cartId,
                    TruckId = request.TruckId,
                    Quantity = request.Quantity,
                    CreatedDate = DateTime.UtcNow,
                };
                await _ICartInterfaces.AdditemAsync(item);
            }
            else
            {
                item.Quantity += request.Quantity;
            }
            await _ICartInterfaces.Save();
        }
    }
}
