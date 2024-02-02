namespace Epilepsy.Project.Models
{
    public class Rating
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public byte? rate { get; set; }
    }
}
