using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class Course_ScheduleDTO
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public int Section_ID { get; set; }
    }
}
