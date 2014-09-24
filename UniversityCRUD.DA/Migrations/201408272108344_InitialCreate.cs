namespace UniversityCRUD.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        CourseID = c.Guid(nullable: false),
                        StudentID = c.Guid(nullable: false),
                        CourseGrade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Age = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProfessorCourses",
                c => new
                    {
                        Professor_ID = c.Guid(nullable: false),
                        Course_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_ID, t.Course_ID })
                .ForeignKey("dbo.Professors", t => t.Professor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Professor_ID)
                .Index(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfessorCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.ProfessorCourses", "Professor_ID", "dbo.Professors");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.Students");
            DropIndex("dbo.ProfessorCourses", new[] { "Course_ID" });
            DropIndex("dbo.ProfessorCourses", new[] { "Professor_ID" });
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropTable("dbo.ProfessorCourses");
            DropTable("dbo.Professors");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}
