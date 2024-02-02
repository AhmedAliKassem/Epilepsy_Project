using Epilepsy.Project.Dtos;
using Epilepsy.Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Epilepsy.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctor = await _context.Doctors.ToListAsync();
            return Ok(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromForm] CreateDoctorDto dto)
        {
            var doctor = new Doctor { About = dto.About, Clinic_Address = dto.Clinic_Address, Education = dto.Education, Email = dto.Email, Experience = dto.Experience, First_Name = dto.First_Name, Last_Name = dto.Last_Name, Hospital_Address = dto.Hospital_Address, Password = dto.Password, Phone = dto.Phone, Photo = dto.Photo, Rating = dto.Rating, Reg_Number = dto.Reg_Number };
            await _context.Doctors.AddAsync(doctor);
            _context.SaveChanges();
            return Ok(doctor);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] CreateDoctorDto dto)
        {
            var doctor = await _context.Doctors.SingleOrDefaultAsync(g => g.Id == id);
            if (doctor == null)
                return NotFound($"No Doctor Was found with Id={id}");
            doctor.About = dto.About; doctor.Clinic_Address = dto.Clinic_Address; doctor.Education = dto.Education; doctor.Email = dto.Email; doctor.Experience = dto.Experience; doctor.First_Name = dto.First_Name; doctor.Last_Name = dto.Last_Name; doctor.Hospital_Address = dto.Hospital_Address; doctor.Password = dto.Password; doctor.Phone = dto.Phone; doctor.Photo = dto.Photo; doctor.Rating = dto.Rating; doctor.Reg_Number = dto.Reg_Number;
            _context.SaveChanges();
            return Ok(doctor);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.SingleOrDefaultAsync(g => g.Id == id);
            if (doctor == null)
                return NotFound($"No Doctor Was found with Id={id}");
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return Ok(doctor);

        }
    }
}
