using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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

namespace Modules.Trucks
{
    public static class TruckEndpoint
    {
        public static IEndpointRouteBuilder MapTruckEndpoint(this WebApplication app)
        {
            const string GetTruckEndpoint = "GetTruck";

            var group = app.MapGroup("trucks");

            // GET / READ
            group.MapGet("/", async (IMediator mediator) =>
                await mediator.Send(new GetTruckQuery(), new CancellationToken()));
            group.MapGet("/{id}", async (int id, IMediator mediator) =>
            {
                TruckDto? truckDto = await mediator.Send(new GetTruckByidQuery(id), new CancellationToken());
                if (truckDto == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(truckDto);
            }).WithName(GetTruckEndpoint);

            // POST / CREATE
            group.MapPost("/", async (CreateTruckCommand command, IMediator mediator, IMapper mapper) =>
            {
                Truck truck = await mediator.Send(command);

                return Results.CreatedAtRoute(GetTruckEndpoint, new { id = truck.Id }, mapper.Map<TruckDto>(truck));
            });

            // PUT / UPDATE
            group.MapPut("/{id}", async (int id, UpdateTruckCommand command, IMediator mediator) =>
            {
                var updatedCommand = command with { Id = id };

                Truck truck = await mediator.Send(updatedCommand);

                return Results.Ok(truck);
            });

            group.MapDelete("/{id}", async (int id, TruckStoreContext dbContext) =>
            {
                var exist = dbContext.Trucks.Find(id);
                if (exist is null)
                {
                    return Results.NotFound();
                }
                dbContext.Remove(exist);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
