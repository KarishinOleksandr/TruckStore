using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Cart.GetById;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Cart;

namespace TruckStore.Application.Cart.GetAll
{
    public class GetAllCartItemHandler : IRequestHandler<GetAllCartItemQuery, List<CartItem>>
    {
        private ICartInterfaces _ICartInterfaces;
        IMediator _mediator;


        public GetAllCartItemHandler(ICartInterfaces iCartInterfaces, IMediator mediator)
        {
            _ICartInterfaces = iCartInterfaces;
            _mediator = mediator;
        }

        public async Task<List<CartItem>> Handle(GetAllCartItemQuery request, CancellationToken cancellationToken)
        {
            var cartId = await _mediator.Send(new GetBuyItemByIdQuery());
            return await _ICartInterfaces.GetAllItemAsync(cartId);
        }
    }
}
