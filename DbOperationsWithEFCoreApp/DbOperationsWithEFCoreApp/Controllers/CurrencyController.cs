using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext1;

        public CurrencyController(AppDbContext appDbContext1)
        {
            this.appDbContext1 = appDbContext1;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCurrency()
        {

            var result = await appDbContext1.Currencies.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)
        {
            var result = await appDbContext1.Currencies.FindAsync(id);
            return Ok(result);
        }
    }
}
