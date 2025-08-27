using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Cart;

namespace TruckStore.Application.Cart.Create
{
    public record class CreateBuyItemCommand(Guid ItemId, int Quantity, Guid TruckId) : IRequest;
}
