using AutoMapper;
using MediatR;
using Modules.Data;
using Modules.Trucks.Application.Command;
using Modules.Trucks.Application.Queries;
using Modules.Trucks.Domain.Dtos;
using Modules.Trucks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Trucks.Application.Handlers
{
    public class DeleteTruckHandler : IRequestHandler<DeleteTruckQuery>
    {
        private readonly TruckStoreContext _context;
        private readonly IMapper _mapper;

        public DeleteTruckHandler(TruckStoreContext context)
        {
            this._context = context;
        }
        public async Task Handle(DeleteTruckQuery request, CancellationToken cancellationToken)
        {
            var truck = await _context.Trucks.FindAsync(new object[] {request.ID});
            if (truck != null)
            {
                _context.Trucks.Remove(truck);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

}
