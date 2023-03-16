using LengoAcademy.Generic;
using LengoAcademy.Context;
using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LengoAcademy.SpecificReposoitory
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IGeneric<Course> generic;
        private readonly LengoAcademyContext context;

        public CourseRepository(
            IGeneric<Course> _generic,
            LengoAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public int Insert(CourseDTO courseDTO)
        {
            var newCourse = new Course()
            {
                Name = courseDTO.Name,
                ImagePath = courseDTO.ImagePath,
                Certificate = courseDTO.Certificate,
                OriginalPrice = courseDTO.OriginalPrice,
                Descount = courseDTO.Descount,
                Descrption = courseDTO.Descrption,
                Duration = courseDTO.Duration,
                Instructor = courseDTO.Instructor,
                SubCategoriesID = courseDTO.SubCategoriesID,
                Requirement = courseDTO.Requirement,
            };
            return generic.Insert(newCourse);
        }
        public List<CourseDTO> LoadAll()
        {
            var courses = new List<CourseDTO>();
            var allcourses = generic.LoadAll();
            if (allcourses?.Any() == true)
            {
                foreach (var course in allcourses)
                {
                    courses.Add(new CourseDTO()
                    {
                        Id = course.Id,
                        Name = course.Name,
                        ImagePath = course.ImagePath,
                        Certificate = course.Certificate,
                        OriginalPrice = course.OriginalPrice,
                        Descount = course.Descount,
                        Descrption = course.Descrption,
                        Duration = course.Duration,
                        Instructor = course.Instructor,
                        SubCategoriesID = course.SubCategoriesID,
                        Requirement = course.Requirement,

                    });
                }
            }
            return courses;
        }
        public CourseDTO Load(int Id)
        {
            var courses = generic.Load(Id);
            if (courses != null)
            {
                var coursesDetails = new CourseDTO()
                {
                    Id = courses.Id,
                    Name = courses.Name,
                    ImagePath = courses.ImagePath,
                    Certificate = courses.Certificate,
                    OriginalPrice = courses.OriginalPrice,
                    Descount = courses.Descount,
                    Descrption = courses.Descrption,
                    Duration = courses.Duration,
                    Instructor = courses.Instructor,
                    SubCategoriesID = courses.SubCategoriesID,
                    Requirement = courses.Requirement,
                };
                return coursesDetails;
            }
            return null;
        }
        public void Update(CourseDTO courseDTO)
        {
            var newCourse = new Course()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                ImagePath = courseDTO.ImagePath,
                Certificate = courseDTO.Certificate,
                OriginalPrice = courseDTO.OriginalPrice,
                Descount = courseDTO.Descount,
                Descrption = courseDTO.Descrption,
                Duration = courseDTO.Duration,
                Instructor = courseDTO.Instructor,
                SubCategoriesID = courseDTO.SubCategoriesID,
                Requirement = courseDTO.Requirement,
            };
            generic.Update(newCourse);
        }
        public void Delete(int Id)
        {
            generic.Delete(Id);
        }
        public List<Course> LoadCoursesBySubCategoriesID(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            List<Course> topics = context.courses.Where(s => s.SubCategoriesID == Id).ToList();
            return topics;
        }
        public List<Course> LoadPlan_ItemByCourse_ID(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            Plan_Item plan_Item = context.plan_Item.Where(c => c.Course_ID == Id).FirstOrDefault();
            List<Course> li = context.courses.Where(c => c.LiPlan_Item.Any(p => p.Plan_ID == plan_Item.Plan_ID)).ToList();
            return li;
        }

        public List<Course> LoadCourses()
        {
            LengoAcademyContext context = new LengoAcademyContext();
            DateTime today = DateTime.Now;
            List<Course> li = context.courses.Where(c => c.LiSection.Any(s => s.StartDate.Month == today.Month && s.StartDate.Year == today.Year)).ToList();
            
            foreach (Course c in li) {
                c.LiSection = new List<Section>();
                c.LiSection.Add( context.sections.Where(s => s.Course_ID == c.Id).OrderByDescending(s => s.StartDate).FirstOrDefault());
            }

            if(li.Count == 0)
            {
/*                List<Course> li = context.courses.Where(c => c.LiSection.OrderByDescending(c=>c.StartDate.f).ToList();
*/          }
            return li;
        }
        public List<Course> LoadAllByMainCategoryID(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            List<Category> liCategory = context.categories.Where(s => s.SubCategoryID == Id).ToList();
            List<Course> liCourse = new List<Course>();
            foreach (Category category in liCategory)
            {
                 liCourse.AddRange( context.courses.Where(c => c.SubCategoriesID == category.Id).ToList());
                
            }
            return liCourse;
        }
        public Section LoadCourseSectionByCourseId(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            return context.sections.Where(s => s.Course_ID == Id).OrderBy(c => c.StartDate).FirstOrDefault();
        }
    }
}
