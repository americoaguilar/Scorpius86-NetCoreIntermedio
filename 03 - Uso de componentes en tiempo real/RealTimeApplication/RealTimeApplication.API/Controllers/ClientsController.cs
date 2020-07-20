using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeApplication.API.Application.Order;
using RealTimeApplication.API.Infrastructure.Framework.SignalR;
using RealTimeApplication.Infrastructure.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientApplicationServices _ClientApplicationServices;
        private readonly SignalRService _signalRService;
        public ClientsController(
            IClientApplicationServices ClientApplicationServices,
            SignalRService signalRService
            )
        {
            _ClientApplicationServices = ClientApplicationServices;
            _signalRService = signalRService;
        }
        // GET: api/<ClientsController>
        [HttpGet]
        public ActionResult<List<ClientDto>> List()
        {
            return Ok(_ClientApplicationServices.List());
        }

        // GET api/<ClientsController>/5
        [HttpGet("{clientId}")]
        public ActionResult<ClientDto> GetByClientId(int clientId)
        {
            return Ok(_ClientApplicationServices.GetByClientId(clientId));
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<ActionResult<ClientDto>> Insert([FromBody] ClientDto client)
        {
            client = _ClientApplicationServices.Insert(client);
            await _signalRService.ClientServerEvents.NewClient(client);
            return Ok(client);
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{clientId}")]
        public ActionResult<ClientDto> Update(int clientId, [FromBody] ClientDto client)
        {
            return Ok(_ClientApplicationServices.Update(clientId, client));
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{clientId}")]
        public ActionResult<ClientDto> Delete(int clientId)
        {
            return Ok(_ClientApplicationServices.Delete(clientId));
        }
    }
}
