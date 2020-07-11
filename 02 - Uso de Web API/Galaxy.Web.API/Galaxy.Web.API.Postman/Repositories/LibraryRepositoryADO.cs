using Galaxy.Web.API.Postman.Data.Entities;
using Galaxy.Web.API.Postman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Web.API.Postman.Repositories
{
    public class LibraryRepositoryADO : ILibraryRepository
    {
        public Author AddAuthor(AuthorDto author)
        {
            throw new NotImplementedException();
        }

        public Author DeleteAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAuthors(string orderBy,string asc)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksForAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Author UpdateAuthor(AuthorDto authorDto)
        {
            throw new NotImplementedException();
        }
    }
}
