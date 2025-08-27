using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Delete
{
    public class DeleteTruckHandler : IRequestHandler<DeleteTruckQuery>
    {
        private readonly ITruckInterface _context;
        private readonly IHubContext<TruckHub> _hubContext;

        public DeleteTruckHandler(ITruckInterface context, IHubContext<TruckHub> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }

        public async Task Handle(DeleteTruckQuery request, CancellationToken cancellationToken)
        {
            var truck = await _context.FindByIdAsync(request.Id, cancellationToken);
            await _context.DeleteAsync(truck, cancellationToken);
            await _hubContext.Clients.All.SendAsync("TrucksUpdatet");
        }
    }
}
