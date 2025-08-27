using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckStore.Application.Trucks
{
    public class TruckHub : Hub
    {
        public async Task Notify()
        {
            await Clients.All.SendAsync("TruckUpdatet");
        }
    }
}
