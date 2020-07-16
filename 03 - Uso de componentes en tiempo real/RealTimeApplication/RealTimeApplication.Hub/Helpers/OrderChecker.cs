using RealTimeApplication.HUB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Helpers
{
    public class OrderChecker
    {
        private readonly Random random;
        private readonly string[] Status = {
            "Grinding beans",
            "Steaming milk",
            "Taking a sip (quality control)",
            "On transit to counter", 
            "Picked up"
        };
        private readonly Dictionary<int, int> StatusTracker = new Dictionary<int, int>();

        public OrderChecker(Random random)
        {
            this.random = random;
        }
        private int GetNextStatusIndex(int OrderNo)
        {
            if (!StatusTracker.ContainsKey(OrderNo))
                StatusTracker.Add(OrderNo, -1);

            StatusTracker[OrderNo]++;
            return StatusTracker[OrderNo];
        }
        public UpdateInfoDto GetUpdate(OrderCoffeDto order)
        {
            if (random.Next(1, 5) != 4)
            {
                return new UpdateInfoDto { IsNew = false };
            }

            var index = GetNextStatusIndex(order.OrderCoffeeId);

            if (Status.Length <= index)
            {
                return new UpdateInfoDto { IsNew = false };
            }

            var result = new UpdateInfoDto
            {
                OrderId = order.OrderCoffeeId,
                IsNew = true,
                Update = Status[index],
                IsFinished = (Status.Length - 1 == index)
            };
            return result;

        }
    }
}
