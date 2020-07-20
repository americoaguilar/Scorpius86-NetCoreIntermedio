using Microsoft.AspNetCore.SignalR.Client;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Infrastructure.Framework.SignalR.Tracking.ServerEvents
{
    public class TrackingServerEvents
    {
        private readonly HubConnection _hubConnection;
        public TrackingServerEvents(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }
        public async Task NewTracking(TrackingDto tracking)
        {
            await _hubConnection.InvokeAsync("NewTracking", tracking);
        }
        public async Task UpdateTracking(TrackingDto tracking)
        {
            await _hubConnection.InvokeAsync("UpdateTracking", tracking);
        }
        public async Task DeleteTracking(TrackingDto tracking)
        {
            await _hubConnection.InvokeAsync("DeleteTracking", tracking);
        }
    }
}
