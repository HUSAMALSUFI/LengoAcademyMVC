using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class PlanDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        public string Name { get; set; }
    }
}
