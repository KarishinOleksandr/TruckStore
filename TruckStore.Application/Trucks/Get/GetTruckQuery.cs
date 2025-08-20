using MediatR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Get
{
    public class GetTruckQuery : IRequest<List<Truck>>
    {
    }
}
