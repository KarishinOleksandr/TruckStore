using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TruckStore.Application.Interfaces;
using TruckStore.Infrastructure.Data;
using TruckStore.Infrastructure.Repository;

namespace TruckStore.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTruckStoreInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<TruckStoreContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITruckInterface, TruckRepository>();
            services.AddScoped<IBrandInterface, TruckRepository>();
            services.AddScoped<ICartInterfaces, CartRepository>();
            services.AddScoped<ICartIdProvider, CartIdProvider>();
            services.AddScoped<ICartIdProvider, CartIdProvider>();
            services.AddScoped<ICartContext, CartContext>();
            services.AddScoped<IOrderInterface, OrderRepository>();
            return services;
        }
    }
}
