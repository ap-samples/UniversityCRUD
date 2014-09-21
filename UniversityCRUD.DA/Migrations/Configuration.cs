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
            studentList.ForEach(s => context.Students.AddOrUpdate(s));
            context.SaveChanges();

            var courseList = new List<Course>()
            {
                new Course(){ Credits = 10, Title = "Maths"},
                new Course(){ Credits = 20, Title = "Advanced maths"},
                new Course(){ Credits = 10, Title = "Physics"}
            };
            courseList.ForEach(c => context.Courses.AddOrUpdate(c));
            context.SaveChanges();

            var enrollments = new List<Enrollment>()
            {
                new Enrollment(){ Course = context.Courses.FirstOrDefault(c => c.Title=="Maths"), Student = context.Students.FirstOrDefault()},
                new Enrollment(){ Course = context.Courses.FirstOrDefault(c => c.Title=="Physics"), Student = context.Students.FirstOrDefault()},
                new Enrollment(){ Course = context.Courses.FirstOrDefault(c => c.Title=="Physics"), 
                    Student = context.Students.FirstOrDefault(s => s.Name == "Boris Ivan")}
            };
            enrollments.ForEach(e => context.Enrollments.AddOrUpdate(e));
            context.SaveChanges();
        }
    }
}
