using MediatR;
using TruckStore.Domain.Brands;

namespace TruckStore.Application.Brands.Get
{
    public class GetBrandsQuery : IRequest<List<Brand>>;
}
