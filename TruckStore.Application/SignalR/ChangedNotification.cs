using MediatR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.SignalR
{
    public record class ChangedNotification(TruckDto Data, KindOfChanges Kind) : INotification;
}
