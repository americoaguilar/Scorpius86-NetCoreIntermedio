using Galaxy.Web.API.Rest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Web.API.Rest.Data.Respositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly List<Author> _authors;

        public LibraryRepository()
        {
            _authors = new List<Author>
            {
                new Author
                {
                    Name = "Erick",
                    Age = 38,
                    Genre = "Masculino",
                    Id = new Guid("313220a5-1fd0-4c5f-9be5-354f5f82d0f2")
                },
                 new Author
                {
                    Name = "Oscar",
                    Age = 16,
                    Genre = "Masculino",
                    Id = new Guid("2808b5f9-8232-43a9-8fb2-40f769a7246f")
                }
            };
        }

        public List<Author> GetAuthors()
        {
            return _authors;
        }

        public Author GetAuthor(Guid id)
        {
            return _authors.Where(w => w.Id == id).FirstOrDefault();
        }

    }
}
