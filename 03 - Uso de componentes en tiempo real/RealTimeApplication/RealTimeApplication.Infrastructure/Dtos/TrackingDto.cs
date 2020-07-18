using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeApplication.Infrastructure.Dtos
{
    public class TrackingDto
    {
        public int TrackingId { get; set; }
        public int OrderId { get; set; }
        public DateTime EstimatedDeliveryTime { get; set; }
        public int TrackingStatusId { get; set; }
        public decimal Total { get; set; }

        public OrderDto Order { get; set; }
        public TrackingStatusDto TrackingStatus { get; set; }
        public List<TrackingProductDto> TrackingProducts { get; set; }
    }
}
