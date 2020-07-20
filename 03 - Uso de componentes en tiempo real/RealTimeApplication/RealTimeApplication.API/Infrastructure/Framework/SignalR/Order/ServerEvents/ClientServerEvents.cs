using Microsoft.AspNetCore.SignalR.Client;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Infrastructure.Framework.SignalR.Client.ServerEvents
{
    public class ClientServerEvents
    {
        private readonly HubConnection _hubConnection;
        public ClientServerEvents(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }
        public async Task NewClient(ClientDto client)
        {
            await _hubConnection.InvokeAsync("NewClient", client);
        }
    }
}
