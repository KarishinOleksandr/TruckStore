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
    public class GetTruckByidHandler : IRequestHandler<GetTruckByidQuery, TruckDto>
    {
        private readonly TruckStoreContext _context;

        public GetTruckByidHandler(TruckStoreContext context)
        {
            this._context = context;
        }

        public async Task<TruckDto> Handle(GetTruckByidQuery request, CancellationToken cancellationToken)
        {
            var truck = await _context.Trucks
                .Where(t => t.Id == request.ID)
                .Select(t => new TruckDto
                (
                    t.Id,
                    t.Model,
                    t.BrandName!.Name.ToString(),
                    t.BrandId,
                    t.maxSpeed,
                    t.maxLiftingCapacity,
                    t.Price,
                    t.ReleaseDate
                ))
                .FirstOrDefaultAsync(cancellationToken);

            return truck;
        }
    }
}
