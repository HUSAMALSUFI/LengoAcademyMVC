using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email Field is Required")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"07(7|8|9)\d{7}")]
        public string Phone { get; set; }
        public int Course_ID { get; set; }
    }
}
