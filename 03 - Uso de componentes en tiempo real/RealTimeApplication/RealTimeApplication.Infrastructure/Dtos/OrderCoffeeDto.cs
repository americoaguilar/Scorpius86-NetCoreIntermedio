using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Models
{
    public class OrderCoffeDto
    {
        public int OrderCoffeeId { get; set; }
        public string Product { get; set; }
        public string Size { get; set; }
    }
}
