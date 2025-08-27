using AppHost.Components;
using AppHost.Extensions;
using AutoMapper;
using TruckStore.Infrastracture;
using TruckStore.Infrastracture.Modules;
using TruckStore.Infrastructure.Data;

namespace AppHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddTruckModule(builder.Configuration);
            builder.Services.AddBrandModule(builder.Configuration);

            builder.Services.AddTruckStoreInfrastructure(builder.Configuration);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(typeof(TruckProfile));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            var mapper = app.Services.GetRequiredService<IMapper>();

            app.UseHttpsRedirection();

            app.UseCookiePolicy();
            app.UserCartContext();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapTruckEndpoint();
            app.MapBrandEndpoint(mapper);

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            await app.MigrateTruckDbAsync();

            app.Run();
        }
    }
}
