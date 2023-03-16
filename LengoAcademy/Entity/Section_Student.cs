using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{

    [Table("section_Student")]
    public class Section_Student
    {
        [ForeignKey("section")]
        public int Section_ID { get; set; }
        public Section section { get; set; }
        [ForeignKey("student")]
        public int StudentID { get; set; }
        public Student student { get; set; }
    }
}
