using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application.Interfaces;
using TruckStore.Domain.Brands;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.Trucks.Create
{
    public class CreateTruckHandler : IRequestHandler<CreateTruckCommand, Truck>
    {
        private readonly ITruckInterface _context;
        private readonly IHubContext<TruckHub> _hubContext;
        public CreateTruckHandler(ITruckInterface context, IHubContext<TruckHub> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }

        public async Task<Truck> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck
            {
                Model = request.Model,
                BrandId = request.BrandId,
                maxSpeed = request.maxSpeed,
                maxLiftingCapacity = request.maxLiftingCapacity,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate
            };
            truck = await _context.AddAsync(truck, cancellationToken);
            await _hubContext.Clients.All.SendAsync("TrucksUpdatet");

            return truck;
        }
    }
}
