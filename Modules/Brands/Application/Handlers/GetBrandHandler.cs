using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Brands.Application.Queries;
using Modules.Brands.Domain.Dtos;
using Modules.Data;
using Modules.Trucks.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Brands.Application.Handlers
{
    public class GetBrandHandler : IRequestHandler<GetBrandQuery, List<BrandDto>>
    {
        private readonly TruckStoreContext _context;

        public GetBrandHandler(TruckStoreContext context)
        {
            this._context = context;
        }

        public async Task<List<BrandDto>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.ToListAsync(cancellationToken);

            var BrandDtos = new List<BrandDto>();

            foreach (var el in brands)
            {
                BrandDtos.Add(new BrandDto
                (
                    el.Id,
                    el.Name
                ));
            }

            return BrandDtos.ToList();
        }
    }
}
