using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "The Name Field is Required")]
        public string FName { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        public string LName { get; set; }
        [Required(ErrorMessage = "The Email Field is Required")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"07(7|8|9)\d{7}")]
        public string PhoneNo { get; set; }
        public int Course_ID { get; set; }
        public int Section_ID { get; set; }
    }
}
