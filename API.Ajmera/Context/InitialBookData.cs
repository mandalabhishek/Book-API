using API.Ajmera.Models;
using System;
using System.Linq;

namespace API.Ajmera.Context
{
    public static class InitialBookData
    {
        public static void Seed(this BookContext dbContext)
        {
            if (!dbContext.Books.Any())
            {
                dbContext.Books.Add(new BookDetails
                {
                    Id = new Guid(),
                    Name = "Automic Habbits",
                    AuthorName = "James Clear"
                });
                dbContext.Books.Add(new BookDetails
                {
                    Id = new Guid(),
                    Name = "Who moved my cheese?",
                    AuthorName = "Spencer Johnson"
                });
                dbContext.Books.Add(new BookDetails
                {
                    Id = new Guid(),
                    Name = "The Psychology of Money",
                    AuthorName = "Morgan Housel"
                });

                dbContext.SaveChanges();
            }
        }
    }
}
