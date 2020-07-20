using Microsoft.AspNetCore.SignalR.Client;
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
        public SignalRService()
        {
            CreateConnection();
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

        public async Task NewOrderServerAsync(OrderDto order)
        {
            await _hubConnection.InvokeAsync("NewOrder", order);
        }

        public async Task NewClientServerAsync(ClientDto client)
        {
            await _hubConnection.InvokeAsync("NewClient", client);
        }
        public async Task NewTrackingServerAsync(TrackingDto tracking)
        {
            await _hubConnection.InvokeAsync("NewTracking", tracking);
        }
        public async Task UpdateTrackingServerAsync(TrackingDto tracking)
        {
            await _hubConnection.InvokeAsync("UpdateTracking", tracking);
        }
        public async Task NewProductServerAsync(ProductDto product)
        {
            await _hubConnection.InvokeAsync("NewProduct", product);
        }

    }
}
