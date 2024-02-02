using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Epilepsy.Project.Models
{
    public class Patient_Companion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string First_Name { get; set; }
        [MaxLength(50)]
        public string Last_Name { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public long Phone { get; set; }
        public byte[] Photo { get; set; }
        public string Email { get; set; }
        public string Notification { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
