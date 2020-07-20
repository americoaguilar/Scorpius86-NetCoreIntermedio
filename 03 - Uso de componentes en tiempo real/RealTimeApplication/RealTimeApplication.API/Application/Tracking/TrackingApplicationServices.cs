using Microsoft.AspNetCore.JsonPatch;
using RealTimeApplication.API.Infrastructure.Data.Repositories.Tracking;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Application.Tracking
{
    public class TrackingApplicationServices : ITrackingApplicationServices
    {
        private readonly ITrackingRepository _trackingRepository;

        public TrackingApplicationServices(ITrackingRepository trackingRepository)
        {
            _trackingRepository = trackingRepository;
        }

        public List<TrackingDto> List()
        {
            return _trackingRepository.List();
        }

        public TrackingDto GetByTrackingId(int trackingId)
        {
            return _trackingRepository.GetByTrackingId(trackingId);
        }
        public TrackingDto Update(int trackingId,TrackingDto tracking)
        {
            tracking.TrackingId = trackingId;
            return _trackingRepository.Update(tracking);
        }

        public TrackingDto UpdatePatch(int trackingId, JsonPatchDocument<TrackingDto> trackingPatch)
        {
            return _trackingRepository.UpdatePatch(trackingId,trackingPatch);
        }

        public TrackingDto Insert(TrackingDto tracking)
        {
            return _trackingRepository.Insert(tracking);
        }
        public TrackingDto Delete(int trackingId)
        {
            return _trackingRepository.Delete(trackingId);
        }
    }
}
