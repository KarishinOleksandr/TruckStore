using MediatR;
using TruckStore.Application.Cart.GetById;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Cart;

namespace TruckStore.Application.Cart.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderInterface _context;

        private readonly ICartInterfaces _cartInterfaces;

        private readonly IMediator _mediator;

        public CreateOrderHandler(IOrderInterface context, ICartInterfaces cartInterfaces, IMediator mediator)
        {
            _context = context;
            _cartInterfaces = cartInterfaces;
            _mediator = mediator;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Name = request.Name,
                SecondName = request.SecondName,
                Adress = request.Adress,
                PhoneNumber = request.PhoneNumber,
                EmailAdress = request.EmailAdress,
                OrderTime = DateTime.UtcNow
            };

            var cartId = await _mediator.Send(new GetBuyItemByIdQuery());

            var items = await _cartInterfaces.GetAllItemAsync(cartId);

            await _context.CreateOrder(order, items);
        }
    }
}
