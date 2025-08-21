using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TruckStore.Infrastructure.Data
{
    public static class DataExtension
    {
        public static async Task MigrateTruckDbAsync(this WebApplication app)
        {
            var scopre = app.Services.CreateScope();
            var dbContext = scopre.ServiceProvider.GetRequiredService<TruckStoreContext>();
        }
    }
}
