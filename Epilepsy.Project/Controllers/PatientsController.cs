using Epilepsy.Project.Dtos;
using Epilepsy.Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epilepsy.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        private new List<string> _allowedExtenstions=new List<string> { ".jpg",".png"};
        private long _maxAllowedPhotoSize = 1048576;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Patient=await _context.Patients.
                Include(d=>d.Doctor).
                Select(m=>new PatientDetailsDto
                {
                    Id = m.Id,
                    DoctorName=m.Doctor.First_Name,
                    About=m.About,
                    DoctorId=m.DoctorId,
                    Email=m.Email,
                    First_Name=m.First_Name,
                    Last_Name=m.Last_Name,
                    Password=m.Password,
                    Phone=m.Phone,
                    Photo=m.Photo,
                    Status=m.Status,
                })
                .ToListAsync();
            return Ok(Patient); 
        }
        [HttpGet("id")]
        public async Task<IActionResult>GetByIdAsync(int id)
        {
            var Patient = await _context.Patients.Include(d => d.Doctor).SingleOrDefaultAsync(m=>m.Id==id);
            if(Patient == null)
                return NotFound();
            var dto = new PatientDetailsDto
            {
                Id = Patient.Id,
                DoctorName = Patient.Doctor.First_Name,
                About = Patient.About,
                DoctorId = Patient.DoctorId,
                Email = Patient.Email,
                First_Name = Patient.First_Name,
                Last_Name = Patient.Last_Name,
                Password = Patient.Password,
                Phone = Patient.Phone,
                Photo = Patient.Photo,
                Status = Patient.Status,
            };
            return Ok(dto);
        }
        [HttpGet("GetByDoctorId")]
        public async Task<IActionResult> GetByDoctorIdAsync(int doctorId)
        {
            var Patient = await _context.Patients
                .Where(m=>m.DoctorId== doctorId).
                Include(d => d.Doctor).
                Select(m => new PatientDetailsDto
                {
                    Id = m.Id,
                    DoctorName = m.Doctor.First_Name,
                    About = m.About,
                    DoctorId = m.DoctorId,
                    Email = m.Email,
                    First_Name = m.First_Name,
                    Last_Name = m.Last_Name,
                    Password = m.Password,
                    Phone = m.Phone,
                    Photo = m.Photo,
                    Status = m.Status,
                })
                .ToListAsync();
            return Ok(Patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]PatientDto dto)
        {
            if(dto.Photo==null)
                return BadRequest("Photo is required!");
            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Photo.FileName).ToLower()))
                return BadRequest("only .png and .jpg");
            if (dto.Photo.Length > _maxAllowedPhotoSize)
                return BadRequest("max allowed size for photo is 1MB");

            var isValidDoctor = await _context.Doctors.AnyAsync(g=>g.Id==dto.DoctorId);
            if (!isValidDoctor)
                return BadRequest("Invalid Doctor Id");

            using var dataStreem = new MemoryStream();
            await dto.Photo.CopyToAsync(dataStreem);
            var Patient = new Patient
            {
                First_Name = dto.First_Name,
                Last_Name = dto.Last_Name,
                Email = dto.Email,
                Password = dto.Password,
                Status = dto.Status,
                Photo = dataStreem.ToArray(),
                Phone = dto.Phone,
                DoctorId = dto.DoctorId,
                About = dto.About,
            };
            await _context.AddAsync(Patient);
            _context.SaveChanges();
            return Ok(Patient);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] PatientDto dto)
        {
            
            var Patient = await _context.Patients.FindAsync(id);
            if (Patient == null)
                return NotFound("No Patient was found with this Id");
            var isValidDoctor = await _context.Doctors.AnyAsync(g => g.Id == dto.DoctorId);
            if (!isValidDoctor)
                return BadRequest("Invalid Doctor Id");
            if (dto.Photo != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Photo.FileName).ToLower()))
                    return BadRequest("only .png and .jpg");
                if (dto.Photo.Length > _maxAllowedPhotoSize)
                    return BadRequest("max allowed size for photo is 1MB");
                using var dataStreem = new MemoryStream();
                await dto.Photo.CopyToAsync(dataStreem);
                Patient.Photo = dataStreem.ToArray();

            }
            Patient.Status = dto.Status;
            Patient.Email=dto.Email;
            Patient.Password=dto.Password;
            Patient.Phone=dto.Phone;
            Patient.DoctorId=dto.DoctorId;
            Patient.About = dto.About;
            Patient.First_Name = dto.First_Name;
            Patient.Last_Name = dto.Last_Name;
            _context.SaveChanges();
            return Ok(Patient);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Patient=await _context.Patients.FindAsync(id);  
            if(Patient==null)
                return NotFound("No Patient was found with this Id");
            _context.Remove(Patient);
            _context.SaveChanges();
            return Ok();
        }
        
    }
}
