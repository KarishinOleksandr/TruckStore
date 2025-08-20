using MediatR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.GetbyId
{
    public class GetTruckByIdQuery : IRequest<Truck>
    {
        public int Id { get; set; }
        public GetTruckByIdQuery(int id) => Id = id;
    }
}
