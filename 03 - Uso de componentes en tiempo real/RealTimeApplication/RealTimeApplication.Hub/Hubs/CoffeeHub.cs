using Microsoft.AspNetCore.SignalR;
using RealTimeApplication.HUB.Helpers;
using RealTimeApplication.HUB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Hubs
{
    public class CoffeeHub: Hub<ICoffeeClient>
    {
        private static readonly OrderChecker _orderChecker = new OrderChecker(new Random());

        public async Task GetUpdateForOrder(OrderCoffeDto order)
        {
            //Context.User.Identity
            await Clients.Others.NewOrder(order);
            UpdateInfoDto result;
            do
            {
                result = _orderChecker.GetUpdate(order);
                await Task.Delay(700);
                if (!result.IsNew)
                {
                    continue;
                }
                await Clients.Caller.ReceiveOrderUpdate(result);
                await Clients.Group("allUpdateReceivers").ReceiveOrderUpdate(result);
            } while (!result.IsFinished);
            await Clients.Caller.Finished(order);
        }

        public async Task Connected(Dictionary<string, string> parameters)
        {
            string connectionId = Context.ConnectionId;
            //Clients.AllExcept(connectionId);
            //Groups.AddToGroupAsync(connectionId, "Grupo Azul");
            //Groups.RemoveFromGroupAsync(connectionId, "Grupo Azul");

            //var httpContext = Context.GetHttpContext();
            //var group = httpContext.Request.Query["group"];
            var group = parameters["group"];
            if (group == "allUpdates")
            {
                await Groups.AddToGroupAsync(connectionId, "allUpdateReceivers");
            }
            
            //return base.OnConnectedAsync();
        }
    }
}
