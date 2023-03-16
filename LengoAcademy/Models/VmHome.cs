using LengoAcademy.Entity;
using System.Collections.Generic;

namespace LengoAcademy.Models
{
    public class VmHome
    {
        public List<Course> LiCourse { get; set; }
        public List<Category> LiCategory { get; set; }
        public Section Section { get; set; }
    }
}
