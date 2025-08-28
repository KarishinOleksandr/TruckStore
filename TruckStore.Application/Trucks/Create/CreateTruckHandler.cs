using MediatR;
using TruckStore.Application.Interfaces;
using TruckStore.Application.SignalR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Create
{
    public class CreateTruckHandler : IRequestHandler<CreateTruckCommand, Truck>
    {
        private readonly ITruckInterface _context;
        private readonly IMediator _mediator;
        public CreateTruckHandler(ITruckInterface context, IMediator mediator)
        {
            this._context = context;
            this._mediator = mediator;
        }

        public async Task<Truck> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck
            {
                Model = request.Model,
                BrandId = request.BrandId,
                maxSpeed = request.maxSpeed,
                maxLiftingCapacity = request.maxLiftingCapacity,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate
            };
            truck = await _context.AddAsync(truck, cancellationToken);

            var dto = new TruckDto(truck.Id, truck.Model, truck.BrandId, truck.maxSpeed, truck.maxLiftingCapacity, truck.Price, truck.ReleaseDate);
            await _mediator.Publish(new ChangedNotification(dto, KindOfChanges.Created), cancellationToken);

            return truck;
        }
    }
}
