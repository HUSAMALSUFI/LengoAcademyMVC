using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("students")]
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [ForeignKey("course")]
        public int Course_ID { get; set; }
        public Course course { get; set; }
        public List<Section_Student> LiSection_Student { get; set; }
    }
}
