using MediatR;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Brands;

namespace TruckStore.Application.Brands.GetbyId
{
    public class GetBrandByIdHandlers : IRequestHandler<GetBrandByIdQuery, Brand?>
    {
        private readonly IBrandInterface _context;
        public GetBrandByIdHandlers(IBrandInterface context)
        {
            this._context = context;
        }
        public async Task<Brand?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _context.GetBrandByIdAsync(request.Id, cancellationToken);
            return brand;
        }
    }
}
