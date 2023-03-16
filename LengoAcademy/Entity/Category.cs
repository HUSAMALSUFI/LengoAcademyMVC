using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("categories")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string IconPath { get; set; }
        [ForeignKey("SubCategory")]
        public int? SubCategoryID { get; set; }
        public Category SubCategory { get; set; }
        public List<Course> LiCourse { get; set; }
    }
}
