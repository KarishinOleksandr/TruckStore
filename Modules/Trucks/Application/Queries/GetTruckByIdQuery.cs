using MediatR;
using Modules.Trucks.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Application.Queries
{
    public class GetTruckByidQuery(int id) : IRequest<TruckDto?>
    {
        public int ID { get; set; } = id;
    }
}
