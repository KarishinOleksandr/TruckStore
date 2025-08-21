using MediatR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.GetbyId
{
    public class GetTruckByIdQuery : IRequest<Truck>
    {
        public Guid Id { get; set; }
        public GetTruckByIdQuery(Guid id) => Id = id;
    }
}
