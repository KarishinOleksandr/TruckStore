using AutoMapper;
using MediatR;
using TruckStore.Domain.Brands;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Update
{
    public class UpdateTruckHandler : IRequestHandler<UpdateTruckCommand, Truck>
    {
        private readonly ITruckInterface _context;
        private readonly IBrandInterface _brandContext;
        private readonly IMapper _mapper;

        public UpdateTruckHandler(ITruckInterface context, IBrandInterface brandContext, IMapper mapper)
        {
            this._context = context;
            this._brandContext = brandContext;
            this._mapper = mapper;
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

            return truck;
        }
    }
}
