using MediatR;
using Microsoft.AspNetCore.SignalR;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Update
{
    public class UpdateTruckHandler : IRequestHandler<UpdateTruckCommand, Truck>
    {
        private readonly ITruckInterface _context;
        private readonly IHubContext<TruckHub> _hubContext;

        public UpdateTruckHandler(ITruckInterface context, IHubContext<TruckHub> _hubContext)
        {
            this._context = context;
            this._hubContext = _hubContext;
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
            await _hubContext.Clients.All.SendAsync("TrucksUpdatet");
            return truck;
        }
    }
}
