using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Epilepsy.Project.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string First_Name { get; set; }
        [MaxLength(50)]
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public string About { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Medicine> Medicines { get; set; }


    }
}
