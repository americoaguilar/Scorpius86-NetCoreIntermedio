using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeApplication.API.Application.Tracking;
using RealTimeApplication.Infrastructure.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingsController : ControllerBase
    {
        private readonly ITrackingApplicationServices _trackingApplicationServices;
        public TrackingsController(ITrackingApplicationServices trackingApplicationServices)
        {
            _trackingApplicationServices = trackingApplicationServices;
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
        public ActionResult<TrackingDto> Insert([FromBody] TrackingDto tracking)
        {
            return Ok(_trackingApplicationServices.Insert(tracking));
        }

        // PUT api/<trackingsController>/5
        [HttpPut("{trackingId}")]
        public ActionResult<TrackingDto> Update(int trackingId, [FromBody] TrackingDto tracking)
        {
            return Ok(_trackingApplicationServices.Update(trackingId, tracking));
        }

        // DELETE api/<trackingsController>/5
        [HttpDelete("{trackingId}")]
        public ActionResult<TrackingDto> Delete(int trackingId)
        {
            return Ok(_trackingApplicationServices.Delete(trackingId));
        }
    }
}
