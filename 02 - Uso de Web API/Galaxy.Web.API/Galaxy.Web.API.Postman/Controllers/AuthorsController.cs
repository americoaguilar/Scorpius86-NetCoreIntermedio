using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Galaxy.Web.API.Postman.Data.Entities;
using Galaxy.Web.API.Postman.Models;
using Galaxy.Web.API.Postman.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Galaxy.Web.API.Postman.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private ILibraryRepository _libraryRepository;
        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        [HttpGet()]
        [Authorize]
        public ActionResult<List<AuthorDto>> GetAuthors([FromQuery] string orderBy, [FromQuery] string asc)
        {
            List<Author> authorsRepo = _libraryRepository.GetAuthors(orderBy, asc);
            List<AuthorDto> authors = Mapper.Map<List<AuthorDto>>(authorsRepo);
            return Ok(authors);
        }

        [HttpGet("{id}",Name = "GetAuthor")]
        public ActionResult<AuthorDto> GetAuthor(Guid id)
        {
            Author authorRepo = _libraryRepository.GetAuthor(id);
            AuthorDto author = Mapper.Map<AuthorDto>(authorRepo);

            if (author == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(author);
            }
        }

        [HttpPost()]
        public ActionResult<AuthorDto> CreateAuthor([FromBody] AuthorDto authorDto)
        {
            Author authorRepo = _libraryRepository.AddAuthor(authorDto);

            //return CreatedAtRoute("GetAuthor", new { id = authorDto.Id }, authorDto);

            AuthorDto author = Mapper.Map<AuthorDto>(authorRepo);

            return CreatedAtAction("CreateAuthor", author);
        }

        [HttpPut("{id}")]
        public ActionResult<AuthorDto> UpdateAuthor(Guid id, [FromBody] AuthorDto authorDto)
        {
            authorDto.Id = id;
            Author authorRepo = _libraryRepository.UpdateAuthor(authorDto);           
            return CreatedAtRoute("GetAuthor", new { id = authorRepo.Id }, authorRepo); ; 
        }

        [HttpDelete("{id}")]
        public ActionResult<AuthorDto> DeleteAuthor(Guid id)
        {
            Author authorRepo = _libraryRepository.DeleteAuthor(id);
            AuthorDto author = Mapper.Map<AuthorDto>(authorRepo);
            return author;
        }
    }
}
