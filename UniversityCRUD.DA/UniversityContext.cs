using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCRUD.BO;

namespace UniversityCRUD.DA
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityContext") { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.StudentID);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.CourseID);

            
        }
    }
}
