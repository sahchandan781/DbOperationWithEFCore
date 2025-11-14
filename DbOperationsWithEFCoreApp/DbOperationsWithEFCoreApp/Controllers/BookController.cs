using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController(AppDbContext appDbContext) : ControllerBase
    {
        private readonly AppDbContext appDbContext = appDbContext;

        [HttpPost()]
        public async Task<IActionResult> AddBook([FromBody] Book model)
        {
            // Hardcoded one Author
            //var author = new Author() { Name = "Chandan", Email = "chandan@iotasol.com" };

            //model.Author = author;
            appDbContext.Books.Add(model);
            await appDbContext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> AddBooks([FromBody] List<Book> model)
        {
            // Validate model
            if (model == null || model.Count == 0)
            {
                return BadRequest("Book list cannot be empty.");
            }
            appDbContext.Books.AddRange(model);
            await appDbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpGet()]
        public async Task<IActionResult> GeAllBooks()
        {
            var result = await appDbContext.Books.ToListAsync();
            return Ok(result);
        }


        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int bookId, [FromBody] Book model)
        {
            var book = appDbContext.Books.FirstOrDefault(x => x.Id == bookId);

            if(book == null)
            {
                return NotFound();
            }

            book.Title = model.Title;
            book.Description = model.Description;

            await appDbContext.SaveChangesAsync();

            return Ok(model);
        }

    }
}
