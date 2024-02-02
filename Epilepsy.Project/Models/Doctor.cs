using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epilepsy.Project.Models
{
    public class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
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
        public List<Chat> Chats { get; set; }
        public List<Medicine> Medicines { get; set; }
    }
}
