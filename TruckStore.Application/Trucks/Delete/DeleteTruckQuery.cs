using MediatR;

namespace TruckStore.Application.Trucks.Delete
{
    public class DeleteTruckQuery : IRequest
    {
        public Guid Id { get; set; }
        public DeleteTruckQuery(Guid id) => Id = id;
    }
}
