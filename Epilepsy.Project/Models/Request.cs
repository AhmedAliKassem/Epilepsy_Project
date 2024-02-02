namespace Epilepsy.Project.Models
{
    public class Request
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public int? Requestesssss { get; set; }


    }
}
