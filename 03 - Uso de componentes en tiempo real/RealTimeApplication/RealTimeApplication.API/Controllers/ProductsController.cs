using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeApplication.API.Application.Product;
using RealTimeApplication.API.Infrastructure.Data.Entities;
using RealTimeApplication.API.Infrastructure.Framework.SignalR;
using RealTimeApplication.Infrastructure.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplicationServices _ProductApplicationServices;
        private readonly SignalRService _signalRService;
        public ProductsController(IProductApplicationServices ProductApplicationServices,SignalRService signalRService)
        {
            _ProductApplicationServices = ProductApplicationServices;
            _signalRService = signalRService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<List<ProductDto>> List()
        {
            return Ok(_ProductApplicationServices.List());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetByProductId(int productId)
        {
            return Ok(_ProductApplicationServices.GetByProductId(productId));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Insert([FromBody] ProductDto product)
        {
            product = _ProductApplicationServices.Insert(product);
            await _signalRService.ProductServerEvents.NewProduct(product);
            return Ok(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{productId}")]
        public ActionResult<ProductDto> Update(int productId, [FromBody] ProductDto product)
        {
            return Ok(_ProductApplicationServices.Update(productId,product));
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{productId}")]
        public ActionResult<ProductDto> Delete(int productId)
        {
            return Ok(_ProductApplicationServices.Delete(productId));
        }
    }
}
