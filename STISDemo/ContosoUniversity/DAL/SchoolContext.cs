using ContosoUniversity.Models;
using ContosoUniversity.Models.STIS;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Person> People { get; set; }

        public DbSet<MonthPlan> MonthPlan { get; set; }
        public DbSet<MonthPlanDetail> MonthPlanDetail { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<PlayListDetail> PlayListDetail { get; set; }
        public DbSet<PlayMedia> PlayMedia { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScheduleDetail> ScheduleDetail { get; set; }
        public DbSet<TimeSlot> TimeSlot { get; set; }
        public DbSet<TimeSlotDetail> TimeSlotDetail { get; set; }
        public DbSet<TimeSlotPlayList> TimeSlotPlayList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));
            this.Configuration.LazyLoadingEnabled = true;
            modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}