using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("plan_Item")]
    public class Plan_Item
    {
        [ForeignKey("course")]
        public int Course_ID { get; set; }
        public Course course { get; set; }
        [ForeignKey("plan")]
        public int Plan_ID { get; set; }
        public Plan plan { get; set; }
    }
}
