using Galaxy.Web.API.Postman.Data.Entities;
using Galaxy.Web.API.Postman.Models;
using System;
using System.Collections.Generic;

namespace Galaxy.Web.API.Postman.Repositories
{
    public interface ILibraryRepository
    {
        List<Author> GetAuthors(string orderBy,string asc);
        Author GetAuthor(Guid id);
        Author AddAuthor(AuthorDto author);
        Author UpdateAuthor(AuthorDto authorDto);
        Author DeleteAuthor(Guid authorId);
        List<Book> GetBooksForAuthor(Guid authorId);
    }
}