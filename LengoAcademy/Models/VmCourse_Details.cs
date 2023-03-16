
using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System.Collections.Generic;

namespace LengoAcademy.Models
{
    public class VmCourse_Details
    {
        public CourseDTO course { get; set; }
        public List<Course> licourses { get; set; }
        public List<Topics> liMainTopics { get; set; }
        public List<Topics> liSubTopics { get; set; }
        public List<Section> LiSection { get; set; }
        public List<Process> LiProcess { get; set; }
        public Section section { get; set; }
    }
}
