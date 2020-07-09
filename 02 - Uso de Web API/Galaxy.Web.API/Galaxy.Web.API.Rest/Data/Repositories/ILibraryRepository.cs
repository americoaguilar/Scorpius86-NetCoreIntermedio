using Galaxy.Web.API.Rest.Data.Entities;
using System;
using System.Collections.Generic;

namespace Galaxy.Web.API.Rest.Data.Respositories
{
    public interface ILibraryRepository
    {
        Author GetAuthor(Guid id);
        List<Author> GetAuthors();
    }
}