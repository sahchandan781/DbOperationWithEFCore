using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetLanguage()
        {
            var result = await appDbContext.Languages.ToListAsync();
            return Ok(result);
        }
    }
}
