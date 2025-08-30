using MediatR;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Get
{
    public class GetTruckHandler : IRequestHandler<GetTruckQuery, List<Truck>>
    {
        private readonly ITruckInterface _context;
        public GetTruckHandler(ITruckInterface context)
        {
            this._context = context;
        }

        public async Task<List<Truck>> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            var trucks = await _context.FindAllTruckAsync(cancellationToken);
            return trucks.ToList();
        }
    }
}
