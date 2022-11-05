using API.Ajmera.Context;
using Microsoft.AspNetCore.Mvc;
using API.Ajmera.Models;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace API.Ajmera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IDbBookContext _dbBookContext;
        private readonly ILogger _logger;
        public BookController(IDbBookContext dbBookContext, ILogger<BookController> logger)
        {
            _dbBookContext = dbBookContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Log message from Get() method");
            return Ok(_dbBookContext.GetBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            _logger.LogInformation("Log message from Get(Guid id) method");
            return Ok(_dbBookContext.GetBooksById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDetails value)
        {
            _logger.LogInformation("Log message from Post() method");
            try
            {
                _dbBookContext.AddBooks(value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something Went Wrong - {ex.Message}");
            }
            return Ok("Book Added Successfully");
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDetails value)
        {
            _logger.LogInformation("Log message from Put() method");
            _dbBookContext.UpdateBook(value);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(Guid id)
        {
            _logger.LogInformation("Log message from Delete(Guid id) method");
            _dbBookContext.DeleteBook(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
