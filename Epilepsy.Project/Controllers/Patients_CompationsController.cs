using Epilepsy.Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epilepsy.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Patients_CompationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Patients_CompationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Patient_Companion = await _context.Doctors.ToListAsync();
            return Ok(Patient_Companion);
        }
    }
}
