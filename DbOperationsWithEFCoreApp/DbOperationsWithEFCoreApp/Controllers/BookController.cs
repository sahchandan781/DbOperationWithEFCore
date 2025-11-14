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
            appDbContext.Books.Add(model);
            await appDbContext.SaveChangesAsync();

            return Ok(model);
        }


        [HttpGet()]
        public async Task<IActionResult> GeAllBooks()
        {
            var result = await appDbContext.Books.ToListAsync();
            return Ok(result);
        }

    }
}
