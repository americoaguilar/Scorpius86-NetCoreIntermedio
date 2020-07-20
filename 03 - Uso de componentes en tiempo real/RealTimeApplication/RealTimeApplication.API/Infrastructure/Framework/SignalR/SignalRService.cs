using Microsoft.AspNetCore.SignalR.Client;
using RealTimeApplication.API.Infrastructure.Framework.SignalR.Client.ServerEvents;
using RealTimeApplication.API.Infrastructure.Framework.SignalR.Order.ServerEvents;
using RealTimeApplication.API.Infrastructure.Framework.SignalR.Product.ServerEvents;
using RealTimeApplication.API.Infrastructure.Framework.SignalR.Tracking.ServerEvents;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Infrastructure.Framework.SignalR
{
    public class SignalRService
    {
        private HubConnection _hubConnection;

        public readonly OrderServerEvents OrderServerEvents;
        public readonly ClientServerEvents ClientServerEvents;
        public readonly ProductServerEvents ProductServerEvents;
        public readonly TrackingServerEvents TrackingServerEvents;

        public SignalRService()
        {
            CreateConnection();
            
            ClientServerEvents = new ClientServerEvents(_hubConnection);
            OrderServerEvents = new OrderServerEvents(_hubConnection);
            ProductServerEvents = new ProductServerEvents(_hubConnection);
            TrackingServerEvents = new TrackingServerEvents(_hubConnection);

            StartConnectionAsync().Wait();
        }

        private void CreateConnection()
        {
            //var hubConnection = new HubConnection("https://localhost:44340", queryStrings);
            //var hubProxy = hubConnection.CreateHubProxy("CoffeeHub");

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44340/OrderHub")
                //.WithUrl("http://realtimeapplication-hub.azurewebsites.net/OrderHub")
                .WithAutomaticReconnect()
                .Build();
        }

        private async Task StartConnectionAsync()
        {
            await _hubConnection.StartAsync();
        }

              
    

    }
}
