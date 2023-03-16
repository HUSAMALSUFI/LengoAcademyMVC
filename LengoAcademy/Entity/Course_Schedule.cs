using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace LengoAcademy.Entity
{
    [Table("course_Schedule")]
    public class Course_Schedule
    {
        public int Id { get; set; }
        public string Day { get; set; }
        [ForeignKey("section")]
        public int Section_ID { get; set; }
        public Section section { get; set; }
    }
}
