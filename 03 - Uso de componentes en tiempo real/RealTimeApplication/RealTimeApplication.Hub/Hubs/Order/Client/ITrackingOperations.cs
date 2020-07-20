using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Hubs.Order.Client
{
    public interface ITrackingOperations
    {
        Task NewTracking(TrackingDto tracking);
        Task UpdateTracking(TrackingDto tracking);
        Task DeleteTracking(TrackingDto tracking);
    }
}
