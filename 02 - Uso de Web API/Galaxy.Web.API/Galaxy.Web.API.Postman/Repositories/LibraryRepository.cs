using AutoMapper;
using Galaxy.Web.API.Postman.Data.Context;
using Galaxy.Web.API.Postman.Data.Entities;
using Galaxy.Web.API.Postman.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Web.API.Postman.Repositories
{
    public class LibraryRepository: ILibraryRepository
    {
        public LibraryContext _libraryContext { get; set; }

        public LibraryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public List<Author> GetAuthors(string orderBy,string asc)
        {
            List<Author> authors;
            IQueryable<Author> query;

                switch (orderBy)
                {
                    case "Name":
                        query = string.IsNullOrEmpty(asc) ? _libraryContext.Authors.OrderBy(o => o.Name) : _libraryContext.Authors.OrderByDescending(o => o.Name);
                        break;
                    case "Age":
                        query = string.IsNullOrEmpty(asc) ? _libraryContext.Authors.OrderBy(o => o.Age) : _libraryContext.Authors.OrderByDescending(o => o.Age);
                    break;
                    default:
                        query = _libraryContext.Authors;
                        break;
                }

            authors = query.ToList();

            return authors;
        }

        public Author GetAuthor(Guid id)
        {
            return _libraryContext.Authors.FirstOrDefault(author => author.Id == id);
        }

        public Author AddAuthor(AuthorDto authorDto)
        {
            authorDto.Id = Guid.NewGuid();
            Author author = new Author();
            Mapper.Map(authorDto, author);
            _libraryContext.Authors.Add(author);
            _libraryContext.SaveChanges();

            return author;
        }

        public List<Book> GetBooksForAuthor(Guid authorId)
        {
            var query = from b in _libraryContext.Books
                        where b.AuthorId == authorId
                        select b; 

            return query.ToList();
        }

        public Author UpdateAuthor(AuthorDto authorDto)
        {
            Author author = GetAuthor(authorDto.Id);
            Mapper.Map(authorDto, author);

            _libraryContext.Authors.Update(author);
            _libraryContext.SaveChanges();
            return author;
        }

        public Author DeleteAuthor(Guid authorId)
        {
            Author author = GetAuthor(authorId);
            _libraryContext.Authors.Remove(author);
            _libraryContext.SaveChanges();

            return author;
        }
    }
}
