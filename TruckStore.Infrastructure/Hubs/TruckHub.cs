using Microsoft.AspNetCore.SignalR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Infrastructure.Hubs
{
    public interface ITruckHub
    {
        Task ReceiveTruckChange(TruckChangedMessage message);
    }

    public class TruckHub : Hub<ITruckHub>
    {
    }
}
