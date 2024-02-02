using Epilepsy.Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Epilepsy.Project.Dtos
{
    public class PatientDetailsDto
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public string About { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

    }
}
