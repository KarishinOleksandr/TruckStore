using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Create
{
    public class CreateTruckHandler : IRequestHandler<CreateTruckCommand, Truck>
    {
        private readonly ITruckInterface _context;
        private readonly IBrandInterface _brandContext;
        private readonly IMapper _mapper;
        public CreateTruckHandler(ITruckInterface context, IMapper mapper, IMediator mediator, IBrandInterface brandcontext)
        {
            this._context = context;
            this._brandContext = brandcontext;
            this._mapper = mapper;
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
            var brandDto = await _brandContext.GetBrandByIdAsync(request.BrandId, cancellationToken);
            truck.BrandName = _mapper.Map<Brand>(brandDto);
            truck = await _context.AddAsync(truck, cancellationToken);

            return truck;
        }
    }
}
