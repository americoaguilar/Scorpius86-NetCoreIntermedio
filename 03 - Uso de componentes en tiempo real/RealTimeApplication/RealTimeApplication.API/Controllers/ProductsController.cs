using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealTimeApplication.API.Application.Product;
using RealTimeApplication.API.Infrastructure.Data.Entities;
using RealTimeApplication.Infrastructure.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplicationServices _ProductApplicationServices;
        public ProductsController(IProductApplicationServices ProductApplicationServices)
        {
            _ProductApplicationServices = ProductApplicationServices;
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
        public ActionResult<ProductDto> Insert([FromBody] ProductDto product)
        {
            return Ok(_ProductApplicationServices.Insert(product));
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
