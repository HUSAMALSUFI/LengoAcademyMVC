using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Domain
{
    public class TopicsDTO
    {
        public int Id { get; set; }
        [Required]
        public string Main { get; set; }
        [Required]
        public string Duration { get; set; }
        public int? SubTopicsID { get; set; }
        public int Course_ID { get; set; }
    }
}
