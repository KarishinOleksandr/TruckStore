using MediatR;

namespace TruckStore.Application.Cart.Create
{
    public record class CreateBuyItemCommand(Guid ItemId, int Quantity, Guid TruckId) : IRequest;
}
