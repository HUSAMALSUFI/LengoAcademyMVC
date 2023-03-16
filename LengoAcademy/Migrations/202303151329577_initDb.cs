namespace LengoAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IconPath = c.String(),
                        SubCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.SubCategoryID)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(),
                        Certificate = c.String(),
                        OriginalPrice = c.Double(nullable: false),
                        Descount = c.Double(),
                        Descrption = c.String(),
                        Requirement = c.String(),
                        Instructor = c.String(),
                        Duration = c.String(),
                        SubCategoriesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FName = c.String(nullable: false, maxLength: 50),
                        LName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 256),
                        PhoneNo = c.String(nullable: false, maxLength: 15),
                        Course_ID = c.Int(nullable: false),
                        Section_ID = c.Int(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.courses", t => t.Course_ID, cascadeDelete: false)
                .ForeignKey("dbo.sections", t => t.Section_ID, cascadeDelete: false)
                .Index(t => t.Course_ID)
                .Index(t => t.Section_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Type = c.String(nullable: false, maxLength: 50),
                        Time = c.String(nullable: false, maxLength: 50),
                        Capacity = c.String(nullable: false, maxLength: 50),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.courses", t => t.Course_ID, cascadeDelete: false)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.course_Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        Section_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.sections", t => t.Section_ID, cascadeDelete: false)
                .Index(t => t.Section_ID);
            
            CreateTable(
                "dbo.section_Student",
                c => new
                    {
                        Section_ID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Section_ID, t.StudentID })
                .ForeignKey("dbo.sections", t => t.Section_ID, cascadeDelete: false)
                .ForeignKey("dbo.students", t => t.StudentID, cascadeDelete: false)
                .Index(t => t.Section_ID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.courses", t => t.Course_ID, cascadeDelete: false)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.plan_Item",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Plan_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Plan_ID })
                .ForeignKey("dbo.courses", t => t.Course_ID, cascadeDelete: false)
                .ForeignKey("dbo.plans", t => t.Plan_ID, cascadeDelete: false)
                .Index(t => t.Course_ID)
                .Index(t => t.Plan_ID);
            
            CreateTable(
                "dbo.plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.process",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Descrption = c.String(),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.courses", t => t.Course_ID, cascadeDelete: false)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Main = c.String(nullable: false, maxLength: 50),
                        Duration = c.String(nullable: false, maxLength: 50),
                        SubTopicsID = c.Int(),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.courses", t => t.Course_ID, cascadeDelete: false)
                .ForeignKey("dbo.topics", t => t.SubTopicsID)
                .Index(t => t.SubTopicsID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        Phone = c.String(nullable: false, maxLength: 15),
                        LogoPath = c.String(),
                        FavIconPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Category_Id })
                .ForeignKey("dbo.courses", t => t.Course_Id, cascadeDelete: false)
                .ForeignKey("dbo.categories", t => t.Category_Id, cascadeDelete: false)
                .Index(t => t.Course_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.categories", "SubCategoryID", "dbo.categories");
            DropForeignKey("dbo.CourseCategories", "Category_Id", "dbo.categories");
            DropForeignKey("dbo.CourseCategories", "Course_Id", "dbo.courses");
            DropForeignKey("dbo.topics", "SubTopicsID", "dbo.topics");
            DropForeignKey("dbo.topics", "Course_ID", "dbo.courses");
            DropForeignKey("dbo.process", "Course_ID", "dbo.courses");
            DropForeignKey("dbo.plan_Item", "Plan_ID", "dbo.plans");
            DropForeignKey("dbo.plan_Item", "Course_ID", "dbo.courses");
            DropForeignKey("dbo.AspNetUsers", "Section_ID", "dbo.sections");
            DropForeignKey("dbo.section_Student", "StudentID", "dbo.students");
            DropForeignKey("dbo.students", "Course_ID", "dbo.courses");
            DropForeignKey("dbo.section_Student", "Section_ID", "dbo.sections");
            DropForeignKey("dbo.course_Schedule", "Section_ID", "dbo.sections");
            DropForeignKey("dbo.sections", "Course_ID", "dbo.courses");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Course_ID", "dbo.courses");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CourseCategories", new[] { "Category_Id" });
            DropIndex("dbo.CourseCategories", new[] { "Course_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.topics", new[] { "Course_ID" });
            DropIndex("dbo.topics", new[] { "SubTopicsID" });
            DropIndex("dbo.process", new[] { "Course_ID" });
            DropIndex("dbo.plan_Item", new[] { "Plan_ID" });
            DropIndex("dbo.plan_Item", new[] { "Course_ID" });
            DropIndex("dbo.students", new[] { "Course_ID" });
            DropIndex("dbo.section_Student", new[] { "StudentID" });
            DropIndex("dbo.section_Student", new[] { "Section_ID" });
            DropIndex("dbo.course_Schedule", new[] { "Section_ID" });
            DropIndex("dbo.sections", new[] { "Course_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "Section_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Course_ID" });
            DropIndex("dbo.categories", new[] { "SubCategoryID" });
            DropTable("dbo.CourseCategories");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.contacts");
            DropTable("dbo.topics");
            DropTable("dbo.process");
            DropTable("dbo.plans");
            DropTable("dbo.plan_Item");
            DropTable("dbo.students");
            DropTable("dbo.section_Student");
            DropTable("dbo.course_Schedule");
            DropTable("dbo.sections");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.courses");
            DropTable("dbo.categories");
        }
    }
}
