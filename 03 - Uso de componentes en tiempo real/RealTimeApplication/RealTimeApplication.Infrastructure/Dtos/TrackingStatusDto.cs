using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeApplication.Infrastructure.Dtos
{
    public class TrackingStatusDto
    {
        public int TrackingStatusId { get; set; }
        public string Description { get; set; }
        public string IconCls { get; set; }
    }
}
