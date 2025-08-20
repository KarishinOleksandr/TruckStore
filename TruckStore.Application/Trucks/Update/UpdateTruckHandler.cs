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
            var BrandName = _brandContext.GetBrandByIdAsync(request.BrandId, cancellationToken);
            truck.BrandName = _mapper.Map<Brand>(BrandName);
            truck = await _context.UpdateAsync(truck, cancellationToken);

            return truck;
        }
    }
}
