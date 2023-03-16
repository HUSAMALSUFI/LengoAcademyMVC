using DareAcademy_DataAccess.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengoAcademy.Entity
{
    [Table("courses")]
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Certificate { get; set; }
        public double OriginalPrice { get; set; }
        public double? Descount { get; set; }
        public string Descrption { get; set; }
        public string Requirement { get; set; }
        public string Instructor { get; set; }
        public string Duration { get; set; }
        public List<ApplicationUser> LiApplicationUser { get; set; }
        public List<Section> LiSection { get; set; }
        public List<Process> LiProcess { get; set; }
        public List<Topics> LiTopics { get; set; }
        public List<Student> LiStudent { get; set; }
        public List<Plan_Item> LiPlan_Item { get; set; }
        [ForeignKey("SubCategories")]
        public int SubCategoriesID { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
