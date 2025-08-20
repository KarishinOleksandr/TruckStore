using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Brands;

namespace TruckStore.Application.Brands.Get
{
    public class GetBrandsQuery : IRequest<List<Brand>>;
}
