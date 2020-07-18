using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Application.Tracking
{
    public interface ITrackingApplicationServices
    {
        TrackingDto Delete(int trackingId);
        TrackingDto GetByTrackingId(int trackingId);
        TrackingDto Insert(TrackingDto tracking);
        List<TrackingDto> List();
        TrackingDto Update(int trackingId, TrackingDto tracking);
    }
}