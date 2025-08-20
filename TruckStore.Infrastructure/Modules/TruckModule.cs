using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Application;
using TruckStore.Application.Trucks.Create;
using TruckStore.Application.Trucks.Get;
using TruckStore.Application.Trucks.GetbyId;
using TruckStore.Application.Trucks.Update;
using TruckStore.Domain.Trucks;
using TruckStore.Infrastructure.Data;

namespace TruckStore.Infrastracture.Modules
{
    public static class TruckModule
    {
        public static IServiceCollection AddTruckModule(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<TruckStoreContext>(opt => opt.UseSqlServer(conf.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(TruckModule).Assembly);
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly));

            return services;
        }

        public static RouteGroupBuilder MapTruckEndpoint(this WebApplication app)
        {
            const string GetTruckEndpoint = "GetTruck";

            var group = app.MapGroup("trucks");

            // GET / READ
            group.MapGet("/", async (IMediator mediator) =>
                await mediator.Send(new GetTruckQuery(), new CancellationToken()));
            group.MapGet("/{id}", async (int id, IMediator mediator) =>
            {
                Truck? truckDto = await mediator.Send(new GetTruckByIdQuery(id), new CancellationToken());
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
