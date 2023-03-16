using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class ContactDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Email Field is Required")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string LogoPath { get; set; }
        public string  FavIconPath { get; set; }
    }
}
