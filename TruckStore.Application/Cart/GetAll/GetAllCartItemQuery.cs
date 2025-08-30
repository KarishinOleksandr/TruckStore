using MediatR;
using TruckStore.Domain.Cart;

namespace TruckStore.Application.Cart.GetAll
{
    public class GetAllCartItemQuery : IRequest<List<CartItem>>
    {
    }
}
