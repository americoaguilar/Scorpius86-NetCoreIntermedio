using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Web.API.Rest.Data.Entities;
using Galaxy.Web.API.Rest.Data.Respositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Galaxy.Web.API.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public List<Author> Get()
        {
            return _libraryRepository.GetAuthors();
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public Author Get(Guid id)
        {
            return _libraryRepository.GetAuthor( id);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
