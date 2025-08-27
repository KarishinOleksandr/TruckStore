using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Application.Cart.GetById
{
    public class GetBuyItemByIdQuery : IRequest<Guid>
    {
    }
}
