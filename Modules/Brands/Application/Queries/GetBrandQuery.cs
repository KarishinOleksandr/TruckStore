using MediatR;
using Modules.Brands.Domain.Dtos;
using Modules.Trucks.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Brands.Application.Queries
{
    public record GetBrandQuery : IRequest<List<BrandDto>>
    {
    }
}
