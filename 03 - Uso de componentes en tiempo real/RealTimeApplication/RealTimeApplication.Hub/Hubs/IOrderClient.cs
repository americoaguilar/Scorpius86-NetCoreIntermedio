using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Hubs
{
    public interface IOrderClient
    {
        Task NewOrder(OrderDto order);
        Task NewClient(ClientDto client);
        Task NewTracking(TrackingDto tracking);
        Task UpdateTracking(TrackingDto tracking);
        Task NewProduct(ProductDto product);

    }
}
