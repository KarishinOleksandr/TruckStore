using MediatR;
using Microsoft.AspNetCore.SignalR;
using TruckStore.Application.SignalR;
using TruckStore.Domain.Trucks;

namespace TruckStore.Infrastructure.Hubs
{
    public class ChangedNotificationNotifier : INotificationHandler<ChangedNotification>
    {
        private readonly IHubContext<TruckHub, ITruckHub> _hub;

        public ChangedNotificationNotifier(IHubContext<TruckHub, ITruckHub> hub)
        {
            _hub = hub;
        }

        public Task Handle(ChangedNotification notification, CancellationToken cancellationToken)
        {
            var message = new TruckChangedMessage(notification.Data.Id, notification.Data, notification.Kind);
            return _hub.Clients.All.ReceiveTruckChange(message);
        }
    }
}
