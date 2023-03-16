using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("process")]
    public class Process
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Descrption { get; set; }
        [ForeignKey("course")]
        public int Course_ID { get; set; }
        public Course course { get; set; }
    }
}
