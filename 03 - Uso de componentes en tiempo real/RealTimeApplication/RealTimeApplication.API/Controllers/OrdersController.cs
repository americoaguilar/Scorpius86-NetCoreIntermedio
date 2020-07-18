using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeApplication.API.Application.Order;
using RealTimeApplication.API.Infrastructure.Data.Entities;
using RealTimeApplication.Infrastructure.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderApplicationServices _orderApplicationServices;
        public OrdersController(IOrderApplicationServices orderApplicationServices)
        {
            _orderApplicationServices = orderApplicationServices;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<List<OrderDto>> List()
        {
            return Ok(_orderApplicationServices.List());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{orderId}")]
        public ActionResult<OrderDto> GetByOrderId(int orderId)
        {
            return Ok(_orderApplicationServices.GetByOrderId(orderId));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<OrderDto> Insert([FromBody] OrderDto order)
        {
            return Ok(_orderApplicationServices.Insert(order));
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{orderId}")]
        public ActionResult<OrderDto> Update(int orderId, [FromBody] OrderDto order)
        {
            return Ok(_orderApplicationServices.Update(orderId,order));
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{orderId}")]
        public ActionResult<OrderDto> Delete(int orderId)
        {
            return Ok(_orderApplicationServices.Delete(orderId));
        }
    }
}
