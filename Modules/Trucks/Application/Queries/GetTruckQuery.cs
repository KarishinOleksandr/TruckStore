using MediatR;
using Modules.Trucks.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Application.Queries
{
    public record GetTruckQuery : IRequest<List<TruckDto>>
    {
    }
}
