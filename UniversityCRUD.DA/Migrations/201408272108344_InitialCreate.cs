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
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.Students");
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}
