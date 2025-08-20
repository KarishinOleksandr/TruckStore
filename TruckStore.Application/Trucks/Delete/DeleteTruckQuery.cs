using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Application.Trucks.Delete
{
    public class DeleteTruckQuery : IRequest
    {
        public int Id { get; set; }
        public DeleteTruckQuery(int id) => Id = id;
    }
}
