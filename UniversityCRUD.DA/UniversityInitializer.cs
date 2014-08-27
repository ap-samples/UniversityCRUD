using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCRUD.BO;

namespace UniversityCRUD.DA
{
    public class UniversityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var studentList = new List<Student>() 
            { 
                new Student(){ Age = 20, EnrollmentDate = DateTime.Now, Name = "Basil Ivanov" },
                new Student(){ Age = 18, EnrollmentDate = DateTime.Now, Name = "Boris Ivan" },
                new Student(){ Age = 27, EnrollmentDate = DateTime.Now, Name = "Masha Ivanova" },
                new Student(){ Age = 23, EnrollmentDate = DateTime.Now, Name = "Vitautas" },
                new Student(){ Age = 21, EnrollmentDate = DateTime.Now, Name = "Ivan" }
            };
            studentList.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courseList = new List<Course>()
            {
                new Course(){ Credits = 10, Title = "Maths"},
                new Course(){ Credits = 20, Title = "Advanced maths"},
                new Course(){ Credits = 10, Title = "Physics"}
            };
            courseList.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>()
            {
                new Enrollment(){ Course = context.Courses.FirstOrDefault(c => c.Title=="Maths"), Student = context.Students.FirstOrDefault()},
                new Enrollment(){ Course = context.Courses.FirstOrDefault(c => c.Title=="Physics"), Student = context.Students.FirstOrDefault()},
                new Enrollment(){ Course = context.Courses.FirstOrDefault(c => c.Title=="Physics"), 
                    Student = context.Students.FirstOrDefault(s => s.Name == "Boris Ivan")}
            };
            enrollments.ForEach(e => context.Enrollments.Add(e));
            context.SaveChanges();


        }
    }
}
