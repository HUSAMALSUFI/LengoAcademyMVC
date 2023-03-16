using LengoAcademy.Domain;
using LengoAcademy.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace LengoAcademy.Models
{
    public class VmEnroll 
    {
        public List<CourseDTO> LiCourse { get; set; }
        public CourseDTO course { get; set; }
        public List<Section> LiSection { get; set; }
        public SignUpDTO signUpDTO { get; set; }
        public List<IdentityRole> liRoles { get; set; }
    }
}
