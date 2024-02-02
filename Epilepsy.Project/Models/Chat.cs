using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Epilepsy.Project.Models
{
    public class Chat
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public string Communication { get; set; }
    }
}