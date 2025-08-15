using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
    public static class TruckModule
    {
        public static IServiceCollection AddTruckModule(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<TruckStoreContext>(opt => opt.UseSqlServer(conf.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(TruckModule).Assembly);
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(TruckModule).Assembly));

            return services;
        }
    }
}
