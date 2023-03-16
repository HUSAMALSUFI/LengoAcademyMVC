using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class Section_StudentDTO
    {
        public int Section_ID { get; set; }
        public int StudentID { get; set; }
    }
}
