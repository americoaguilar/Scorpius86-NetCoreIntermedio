using RealTimeApplication.HUB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Hubs
{
    public interface ICoffeeClient
    {
        Task NewOrder(OrderCoffeDto order);
        Task ReceiveOrderUpdate(UpdateInfoDto info);
        Task Finished(OrderCoffeDto order);
    }
}
