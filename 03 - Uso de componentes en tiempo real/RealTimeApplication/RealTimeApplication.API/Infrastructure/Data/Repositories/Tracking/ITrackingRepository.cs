using Microsoft.AspNetCore.JsonPatch;
using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Infrastructure.Data.Repositories.Tracking
{
    public interface ITrackingRepository
    {
        TrackingDto Delete(int trackingId);
        TrackingDto GetByTrackingId(int trackingId);
        TrackingDto Insert(TrackingDto tracking);
        List<TrackingDto> List();
        TrackingDto Update(TrackingDto tracking);
        TrackingDto UpdatePatch(int trackingId, JsonPatchDocument<TrackingDto> trackingPatch);
    }
}