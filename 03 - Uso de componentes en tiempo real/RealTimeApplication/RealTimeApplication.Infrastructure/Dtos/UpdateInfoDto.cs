using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Models
{
    public class UpdateInfoDto
    {
        public int OrderCoffeeId { get; set; }
        public bool IsNew { get; set; }
        public string Update { get; set; }
        public bool IsFinished { get; set; }
    }
}
