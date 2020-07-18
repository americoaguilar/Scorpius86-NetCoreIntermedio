using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeApplication.API.Application.Order;
using RealTimeApplication.Infrastructure.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientApplicationServices _ClientApplicationServices;
        public ClientsController(IClientApplicationServices ClientApplicationServices)
        {
            _ClientApplicationServices = ClientApplicationServices;
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
        public ActionResult<ClientDto> Insert([FromBody] ClientDto client)
        {
            return Ok(_ClientApplicationServices.Insert(client));
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
