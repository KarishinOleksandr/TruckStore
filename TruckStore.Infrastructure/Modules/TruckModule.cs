using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TruckStore.Application;
using TruckStore.Application.Trucks;
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

        public static void MapTruckEndpoint(this WebApplication app)
        {
            app.MapHub<TruckHub>("/truckHub");
        }
    }
}
