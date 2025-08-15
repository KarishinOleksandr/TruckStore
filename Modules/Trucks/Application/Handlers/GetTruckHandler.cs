using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Data;
using Modules.Trucks.Application.Queries;
using Modules.Trucks.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Application.Handlers
{
    public class GetTruckHandler : IRequestHandler<GetTruckQuery, List<TruckDto>>
    {
        private readonly TruckStoreContext _context;

        public GetTruckHandler(TruckStoreContext context)
        {
            this._context = context;
        }

        public async Task<List<TruckDto>> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            Task.Delay(500).Wait();
            var trucks = await _context.Trucks.Include(t => t.BrandName).ToListAsync(cancellationToken);

            var truckDtos = new List<TruckDto>();

            foreach (var el in trucks)
            {
                truckDtos.Add(new TruckDto
                (
                    el.Id,
                    el.Model,
                    el.BrandName!.Name.ToString(),
                    el.BrandId,
                    el.maxSpeed,
                    el.maxLiftingCapacity,
                    el.Price,
                    el.ReleaseDate
                ));
            }

            return truckDtos.ToList();
        }
    }
}
