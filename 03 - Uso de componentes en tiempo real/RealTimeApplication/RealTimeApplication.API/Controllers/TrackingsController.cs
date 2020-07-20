using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RealTimeApplication.API.Application.Tracking;
using RealTimeApplication.API.Infrastructure.Framework.SignalR;
using RealTimeApplication.Infrastructure.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingsController : ControllerBase
    {
        private readonly ITrackingApplicationServices _trackingApplicationServices;
        private readonly SignalRService _signalRService;
        public TrackingsController(ITrackingApplicationServices trackingApplicationServices,SignalRService signalRService)
        {
            _trackingApplicationServices = trackingApplicationServices;
            _signalRService = signalRService;
        }
        // GET: api/<trackingsController>
        [HttpGet]
        public ActionResult<List<TrackingDto>> List()
        {
            return Ok(_trackingApplicationServices.List());
        }

        // GET api/<trackingsController>/5
        [HttpGet("{trackingId}")]
        public ActionResult<TrackingDto> GetByTrackingId(int trackingId)
        {
            return Ok(_trackingApplicationServices.GetByTrackingId(trackingId));
        }

        // POST api/<trackingsController>
        [HttpPost]
        public async Task<ActionResult<TrackingDto>> Insert([FromBody] TrackingDto tracking)
        {
            tracking = _trackingApplicationServices.Insert(tracking);
            await _signalRService.NewTrackingServerAsync(tracking);
            return Ok(tracking);
        }

        // PUT api/<trackingsController>/5
        [HttpPut("{trackingId}")]
        public async Task<ActionResult<TrackingDto>> Update(int trackingId, [FromBody] TrackingDto tracking)
        {
            tracking = _trackingApplicationServices.Update(trackingId, tracking);
            await _signalRService.UpdateTrackingServerAsync(tracking);
            return Ok(tracking);
        }

        [HttpPatch("{trackingId}")]
        public async Task<ActionResult<TrackingDto>> Update(int trackingId, [FromBody] JsonPatchDocument<TrackingDto> trackingPatch)
        {
            TrackingDto tracking = _trackingApplicationServices.UpdatePatch(trackingId, trackingPatch);
            await _signalRService.UpdateTrackingServerAsync(tracking);
            return Ok(tracking);
        }

        // DELETE api/<trackingsController>/5
        [HttpDelete("{trackingId}")]
        public ActionResult<TrackingDto> Delete(int trackingId)
        {
            return Ok(_trackingApplicationServices.Delete(trackingId));
        }
    }
}
