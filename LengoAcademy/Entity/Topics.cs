using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("topics")]
    public class Topics
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Main { get; set; }
        [Required]
        [StringLength(50)]
        public string Duration { get; set; }
        [ForeignKey("SubTopics")]
        public int? SubTopicsID { get; set; }
        public Topics SubTopics { get; set; }
        [ForeignKey("course")]
        public int Course_ID { get; set; }
        public Course course { get; set; }

    }
}
