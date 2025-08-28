using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckStore.Domain.Trucks;

namespace TruckStore.Application.SignalR
{
    public record class ChangedNotification(TruckDto Data, KindOfChanges Kind) : INotification;
}
