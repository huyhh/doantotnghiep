using HospitalAppoimentSolution.Data.Models;
using System.Data.Entity;
using HospitalAppoimentSolution.Data.Models;

namespace HospitalAppoimentSolution.Services
{
    public class EntitiesDbContext : DbContext
    {
        public EntitiesDbContext() : base("conStr")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AssignPosition> AssignPositions { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Appoinment> Appoinments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ShiftTime> ShiftTimes { get; set; }
        public static EntitiesDbContext Create()
        {
            return new EntitiesDbContext();
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
