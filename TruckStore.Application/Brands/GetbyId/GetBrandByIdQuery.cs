using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;

namespace TruckStore.Application.Brands.GetbyId
{
    public class GetBrandByIdQuery : IRequest<Brand?>
    {
        public int Id { get; set; }
        public GetBrandByIdQuery(int id)=> Id = id;
    }
}
