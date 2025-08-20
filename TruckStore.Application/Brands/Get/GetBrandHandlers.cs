using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;

namespace TruckStore.Application.Brands.Get
{
    public class GetBrandHandlers : IRequestHandler<GetBrandsQuery, List<Brand>>
    {
        private readonly IBrandInterface _context;

        public GetBrandHandlers(IBrandInterface context)
        {
            this._context = context;
        }

        public async Task<List<Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.FindAllBrandAsync(cancellationToken);
            return brands.ToList();
        }
    }
}
