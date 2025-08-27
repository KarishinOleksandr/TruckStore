using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Cart;

namespace TruckStore.Application.Cart.GetAll
{
    public class GetAllCartItemQuery : IRequest<List<CartItem>>
    {
    }
}
