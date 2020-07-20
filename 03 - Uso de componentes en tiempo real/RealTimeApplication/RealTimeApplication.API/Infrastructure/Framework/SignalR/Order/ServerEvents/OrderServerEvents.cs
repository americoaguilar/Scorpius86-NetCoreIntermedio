using Microsoft.AspNetCore.SignalR.Client;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Infrastructure.Framework.SignalR.Order.ServerEvents
{
    public class OrderServerEvents
    {
        private readonly HubConnection _hubConnection;
        public OrderServerEvents(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }
        public async Task NewOrder(OrderDto order)
        {
            await _hubConnection.InvokeAsync("NewOrder", order);
        }
    }
}
