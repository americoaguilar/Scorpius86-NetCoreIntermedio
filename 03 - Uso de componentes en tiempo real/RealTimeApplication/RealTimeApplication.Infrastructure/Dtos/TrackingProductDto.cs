using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeApplication.Infrastructure.Dtos
{
    public class TrackingProductDto
    {
        public int TrackingProductId { get; set; }
        public int TrackingId { get; set; }
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}
