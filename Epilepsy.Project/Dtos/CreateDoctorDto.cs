using System.ComponentModel.DataAnnotations;

namespace Epilepsy.Project.Dtos
{
    public class CreateDoctorDto
    {
        public string First_Name { get; set; }
        [MaxLength(50)]
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public int Reg_Number { get; set; }
        public string Experience { get; set; }
        public string About { get; set; }
        public string Education { get; set; }
        public string Hospital_Address { get; set; }
        public string Clinic_Address { get; set; }
        public byte Photo { get; set; }
        public string Rating { get; set; }
        public string Email { get; set; }
    }
}
