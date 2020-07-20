using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealTimeApplication.HUB.Hubs.Order.Client;
using RealTimeApplication.Infrastructure.Dtos;

namespace RealTimeApplication.HUB.Hubs
{
    public partial class OrderHub : Hub<IOrderClient>
    {
        public async Task NewOrder(OrderDto order)
        {
            await Clients.All.NewOrder(order);
        }
        public async Task NewClient(ClientDto client)
        {
            await Clients.All.NewClient(client);
        }
        public async Task NewTracking(TrackingDto tracking)
        {
            await Clients.All.NewTracking(tracking);
        }
        public async Task UpdateTracking(TrackingDto tracking)
        {
            await Clients.All.UpdateTracking(tracking);
        }
        public async Task DeleteTracking(TrackingDto tracking)
        {
            await Clients.All.DeleteTracking(tracking);
        }
        public async Task NewProduct(ProductDto product)
        {
            await Clients.All.NewProduct(product);
        }
    }
}
