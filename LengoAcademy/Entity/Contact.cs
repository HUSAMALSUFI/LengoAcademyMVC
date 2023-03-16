using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("contacts")]
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        public string LogoPath { get; set; }
        public string FavIconPath { get; set; }
    }
}
