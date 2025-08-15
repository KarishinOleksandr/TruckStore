using MediatR;
using Modules.Data;
using Modules.Trucks.Application.Command;
using Modules.Trucks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Application.Handlers
{
    public class CreateTruckHandler : IRequestHandler<CreateTruckCommand, Truck>
    {
        private readonly TruckStoreContext _context;

        public CreateTruckHandler(TruckStoreContext context)
        {
            this._context = context;
        }

        public async Task<Truck> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck truck = new Truck
            {
                Model = request.Model,
                BrandId = request.BrandId,
                maxSpeed = request.maxSpeed,
                maxLiftingCapacity = request.maxLiftingCapacity,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate,
            };
            truck.BrandName = await _context.Brands.FindAsync(request.BrandId);
            await _context.AddAsync(truck);
            await _context.SaveChangesAsync();

            return truck;
        }
    }
}
