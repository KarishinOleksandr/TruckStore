using MediatR;
using TruckStore.Domain.Brands;

namespace TruckStore.Application.Brands.GetbyId
{
    public class GetBrandByIdQuery : IRequest<Brand?>
    {
        public Guid Id { get; set; }
        public GetBrandByIdQuery(Guid id)=> Id = id;
    }
}
