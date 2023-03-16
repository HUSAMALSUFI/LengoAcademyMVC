using LengoAcademy.Entity;
using System.Collections.Generic;

namespace LengoAcademy.Models
{
    public class VmCourses
    {
        public List<Course> LiCourse { get; set; }
        public List<Category> MainLiCategory { get; set; }
        public List<Category> LiSubCategory { get; set; }
        public List<Category> LiSubCategoryById { get; set; }
    }
}
