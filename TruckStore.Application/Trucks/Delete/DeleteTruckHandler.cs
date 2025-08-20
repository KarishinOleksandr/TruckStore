using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Delete
{
    public class DeleteTruckHandler : IRequestHandler<DeleteTruckQuery>
    {
        private readonly ITruckInterface _context;

        public DeleteTruckHandler(ITruckInterface context)
        {
            this._context = context;
        }

        public async Task Handle(DeleteTruckQuery request, CancellationToken cancellationToken)
        {
            var truck = await _context.FindByIdAsync(request.Id, cancellationToken);
            await _context.DeleteAsync(truck, cancellationToken);
        }
    }
}
