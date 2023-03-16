using DareAcademy_DataAccess.Application;
using LengoAcademy.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;

namespace LengoAcademy.Context
{
    public class LengoAcademyContext : IdentityDbContext<ApplicationUser>
    {
       /* static LengoAcademyContext()
        {
            Database.SetInitializer<LengoAcademyContext>(null);
        }*/
        public LengoAcademyContext() : base("name=TConnection")
        {

        }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Contact> contacts { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<Course_Schedule> course_Schedule { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Section> sections { get; set; }
        public virtual DbSet<Section_Student> section_Student { get; set; }
        public virtual DbSet<Student> student { get; set; }
        public virtual DbSet<Topics> topics { get; set; }
        public virtual DbSet<Plan> plans { get; set; }
        public virtual DbSet<Plan_Item> plan_Item { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section_Student>().HasKey(OP => new { OP.Section_ID, OP.StudentID });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plan_Item>().HasKey(OP => new { OP.Course_ID, OP.Plan_ID });
            base.OnModelCreating(modelBuilder);
        }
}
}
