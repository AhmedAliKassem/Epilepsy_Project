using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml;
namespace Epilepsy.Project.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Patient_Companion> Patient_Companions { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chat>().HasKey(e => new
            {

                e.DoctorId,
                e.PatientId
            });
            modelBuilder.Entity<Medicine>().HasKey(e => new
            {

                e.DoctorId,
                e.PatientId
            });
            modelBuilder.Entity<Request>().HasKey(e => new
            {

                e.DoctorId,
                e.PatientId
            });
            modelBuilder.Entity<Review>().HasKey(e => new
            {

                e.DoctorId,
                e.PatientId
            });
            modelBuilder.Entity<Rating>().HasKey(e => new
            {

                e.DoctorId,
                e.PatientId
            });
        }



    }
}
   
