using Microsoft.AspNetCore.SignalR.Client;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Infrastructure.Framework.SignalR.Product.ServerEvents
{
    public class ProductServerEvents
    {
        private readonly HubConnection _hubConnection;
        public ProductServerEvents(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }
        public async Task NewProduct(ProductDto product)
        {
            await _hubConnection.InvokeAsync("NewProduct", product);
        }
    }
}
