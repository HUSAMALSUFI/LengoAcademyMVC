using DareAcademy_DataAccess.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("sections")]
    public class Section
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Time { get; set; }
        [Required]
        [StringLength(50)]
        public string Capacity { get; set; }
        [ForeignKey("course")]
        public int Course_ID { get; set; }
        public Course course { get; set; }
        public List<ApplicationUser> LiApplicationUser { get; set; }
        public List<Section_Student> LiSection_Student { get; set; }
        public List<Course_Schedule> LiCourse_Schedule { get; set; }
    }
}
