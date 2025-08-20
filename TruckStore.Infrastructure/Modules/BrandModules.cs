using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruckStore.Domain.Brands;
using TruckStore.Infrastructure.Data;

namespace TruckStore.Infrastracture.Modules
{
    public static class BrandModel
    {
        public static IServiceCollection AddBrandModule(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<TruckStoreContext>(opt => opt.UseSqlServer(conf.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(BrandModel).Assembly);
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(typeof(BrandModel).Assembly));

            return services;
        }

        public static RouteGroupBuilder MapBrandEndpoint(this WebApplication app, IMapper mapper)
        {
            var group = app.MapGroup("brands");

            group.MapGet("/", async (TruckStoreContext dbContext) => await dbContext.Brands.AsNoTracking().Select(brand => mapper.Map<BrandDto>(brand)).ToListAsync());

            return group;
        }
    }
}
