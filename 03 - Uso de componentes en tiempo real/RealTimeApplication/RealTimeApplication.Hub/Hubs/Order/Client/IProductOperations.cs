using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Hubs.Order.Client
{
    public partial interface IOrderOperations
    {
        Task NewOrder(OrderDto order);
    }
}
