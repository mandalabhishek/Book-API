using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using API.Ajmera.Context;
using API.Ajmera.Models;
using System.Collections.Generic;
using API.Ajmera.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace API.Ajmera.Test
{
    [TestClass]
    public class BookControllerTest
    {
        public readonly Mock<IDbBookContext> dbBook;
        public readonly Mock<ILogger<BookController>> logger;
        public readonly BookController bookController;
             
        public BookControllerTest()
        {
            dbBook = new Mock<IDbBookContext>();
            logger = new Mock<ILogger<BookController>>();
            bookController = new BookController(dbBook.Object, logger.Object);
        }

        [TestMethod]
        public void GetMethodTest()
        {
            var actual = bookController.Get();
            var expected = typeof(OkObjectResult);

            Assert.IsInstanceOfType(actual, expected);
        }

        [TestMethod]
        public void ReturnsExactNumberOfEmployees()
        {
        }
    }
}
