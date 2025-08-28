using MediatR;
using TruckStore.Application.Interfaces;
using TruckStore.Application.SignalR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Delete
{
    public class DeleteTruckHandler : IRequestHandler<DeleteTruckQuery>
    {
        private readonly ITruckInterface _context;
        private readonly IMediator _mediator;

        public DeleteTruckHandler(ITruckInterface context, IMediator mediator)
        {
            this._context = context;
            this._mediator = mediator;
        }

        public async Task Handle(DeleteTruckQuery request, CancellationToken cancellationToken)
        {
            var truck = await _context.FindByIdAsync(request.Id, cancellationToken);
            await _context.DeleteAsync(truck, cancellationToken);

            var dto = new TruckDto(truck.Id, truck.Model, truck.BrandId, truck.maxSpeed, truck.maxLiftingCapacity, truck.Price, truck.ReleaseDate);
            await _mediator.Publish(new ChangedNotification(dto, KindOfChanges.Deleted), cancellationToken);
        } 
    }
}
