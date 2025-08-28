using MediatR;
using Microsoft.AspNetCore.SignalR;
using TruckStore.Application.Interfaces;
using TruckStore.Application.SignalR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Update
{
    public class UpdateTruckHandler : IRequestHandler<UpdateTruckCommand, Truck>
    {
        private readonly ITruckInterface _context;
        private readonly IMediator _mediator;

        public UpdateTruckHandler(ITruckInterface context, IMediator mediator)
        {
            this._context = context;
            this._mediator = mediator;
        }
        public async Task<Truck> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = await _context.FindByIdAsync(request.Id, cancellationToken);

            truck.Model = request.Model;
            truck.BrandId = request.BrandId;
            truck.maxSpeed = request.maxSpeed;
            truck.maxLiftingCapacity = request.maxLiftingCapacity;
            truck.Price = request.Price;
            truck.ReleaseDate = request.ReleaseDate;

            await _context.UpdateAsync(truck, cancellationToken);

            var dto = new TruckDto(truck.Id, truck.Model, truck.BrandId, truck.maxSpeed, truck.maxLiftingCapacity, truck.Price, truck.ReleaseDate);
            await _mediator.Publish(new ChangedNotification(dto, KindOfChanges.Updated), cancellationToken);
            return truck;
        }
    }
}
