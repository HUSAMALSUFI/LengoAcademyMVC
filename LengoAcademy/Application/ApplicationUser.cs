using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using LengoAcademy.Entity;

namespace DareAcademy_DataAccess.Application
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FName { get; set; }
        [Required]
        [StringLength(50)]
        public string LName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string PhoneNo { get; set; }
        [ForeignKey("course")]
        public int Course_ID { get; set; }
        public Course course { get; set; }
        [ForeignKey("section")]
        public int Section_ID { get; set; }
        public Section section { get; set; }
    }
}
