using MediatR;
using Modules.Trucks.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Application.Queries
{
    public class DeleteTruckQuery : IRequest
    {
        public int ID { get; set; }
        public DeleteTruckQuery(int id) => ID = id;


    }
}
