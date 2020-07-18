using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeApplication.Infrastructure.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public decimal Comission { get; set; }

        public ClientDto Client { get; set; }
        public List<TrackingDto> Trackings { get; set; }
    }
}
