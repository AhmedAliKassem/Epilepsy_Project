using Epilepsy.Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epilepsy.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedecinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedecinesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Medicine = await _context.Medicines.ToListAsync();
            return Ok(Medicine);
        }
    }
}
