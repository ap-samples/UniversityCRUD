namespace UniversityCRUD.DA.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UniversityCRUD.BO;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityCRUD.DA.UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UniversityCRUD.DA.UniversityContext";
        }

        protected override void Seed(UniversityCRUD.DA.UniversityContext context)
        {
            var studentList = new List<Student>() 
            { 
                new Student(){ Age = 20, EnrollmentDate = DateTime.Now, Name = "Basil Ivanov" },
                new Student(){ Age = 18, EnrollmentDate = DateTime.Now, Name = "Boris Ivan" },
                new Student(){ Age = 27, EnrollmentDate = DateTime.Now, Name = "Masha Ivanova" },
                new Student(){ Age = 23, EnrollmentDate = DateTime.Now, Name = "Vytautas" },
                new Student(){ Age = 21, EnrollmentDate = DateTime.Now, Name = "Ivan" }
            };
            studentList.ForEach(s => context.Students.AddOrUpdate(h => h.Name, s));
            context.SaveChanges();

            var courseList = new List<Course>()
            {
                new Course(){ Credits = 10, Title = "Maths"},
                new Course(){ Credits = 20, Title = "Advanced maths"},
                new Course(){ Credits = 10, Title = "Physics"},
                new Course(){ Credits = 10, Title = "Basic chemistry"},
                new Course(){ Credits = 20, Title = "Advanced chemistry"}
            };
            courseList.ForEach(c => context.Courses.AddOrUpdate(course => course.Title, c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>()
            {
                new Enrollment(){ CourseID = context.Courses.FirstOrDefault(c => c.Title=="Maths").ID, StudentID = context.Students.FirstOrDefault().ID},
                new Enrollment(){ CourseID = context.Courses.FirstOrDefault(c => c.Title=="Physics").ID, StudentID = context.Students.FirstOrDefault().ID},
                new Enrollment(){ CourseID = context.Courses.FirstOrDefault(c => c.Title=="Physics").ID, 
                    StudentID = context.Students.FirstOrDefault(s => s.Name == "Boris Ivan").ID}
            };
            enrollments.ForEach(e =>
                context.Enrollments.AddOrUpdate(enr => new { enr.CourseID, enr.StudentID }, e));
            context.SaveChanges();

            var professors = new List<Professor>()
            {
                new Professor(){ FirstName = "John", LastName="Jack Jameson", ContactEmail = "j.jameson@univ.edu",
                PublicationCount = 20, 
                CoursesTeached = new HashSet<Course>(){ context.Courses.FirstOrDefault(c => c.Title == "Basic chemistry") }}
            };
            professors.ForEach(p => context.Professors.AddOrUpdate(p));
            context.SaveChanges();
        }
    }
}
