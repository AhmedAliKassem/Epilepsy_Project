namespace Epilepsy.Project.Models
{
    public class Medicine
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public string Diagnosis { get; set; }
        public string Name { get; set; }
        public string Daily_Dosage { get; set; }
        public string Course_Duration { get; set; }
    }
}
