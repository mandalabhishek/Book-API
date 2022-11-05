using API.Ajmera.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Ajmera.Context
{
    public class BookContext : DbContext, IDbBookContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookDetails> Books { get; set; }

        public void AddBooks(BookDetails bookDetails)
        {
            bookDetails.Id = new Guid();
            Books.Add(bookDetails);
            SaveChanges();
        }

        public void DeleteBook(Guid id)
        {
            var book = Books.FirstOrDefault(s => s.Id == id);
            if (book != null)
            {
                Books.Remove(book);
                SaveChanges();
            }
        }

        public IEnumerable<BookDetails> GetBooks()
        {
            return Books;
        }

        public BookDetails GetBooksById(Guid id)
        {
            return Books.FirstOrDefault(s => s.Id == id);
        }

        public void UpdateBook(BookDetails bookDetails)
        {
            Books.Update(bookDetails);
        }
    }
}
