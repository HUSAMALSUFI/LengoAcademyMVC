using DareAcademy_DataAccess.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class SectionDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Capacity { get; set; }
        public int Course_ID { get; set; }
        public List<Course_ScheduleDTO> LiCourse_Schedule { get; set; }
    }
}
