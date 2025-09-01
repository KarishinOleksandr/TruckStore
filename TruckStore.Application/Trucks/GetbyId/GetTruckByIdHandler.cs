using AutoMapper;
using MediatR;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.GetbyId
{
    public class GetTruckByIdHandler : IRequestHandler<GetTruckByIdQuery, Truck>
    {
        private readonly ITruckInterface _context;
        public GetTruckByIdHandler(ITruckInterface context)
        {
            this._context = context;
        }
      

        public async Task<Truck> Handle(GetTruckByIdQuery request, CancellationToken cancellationToken)
        {
            var truck = await _context.FindByIdAsync(request.Id, cancellationToken);

            return truck;
        }
    }
}
