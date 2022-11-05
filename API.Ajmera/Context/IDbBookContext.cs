using API.Ajmera.Models;
using System;
using System.Collections.Generic;

namespace API.Ajmera.Context
{
    public interface IDbBookContext
    {
        public IEnumerable<BookDetails> GetBooks();
        public BookDetails GetBooksById(Guid id);
        public void AddBooks(BookDetails bookDetails);
        public void UpdateBook(BookDetails bookDetails);
        public void DeleteBook(Guid id);
    }
}
