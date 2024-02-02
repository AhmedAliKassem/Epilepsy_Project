using System.ComponentModel.DataAnnotations;

namespace Epilepsy.Project.Dtos
{
    public class PatientDto
    {
        [MaxLength(50)]
        public string First_Name { get; set; }
        [MaxLength(50)]
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public string About { get; set; }
        public IFormFile? Photo { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public int DoctorId { get; set; }
    }
}
