using System.ComponentModel.DataAnnotations;

namespace LengoAcademy.Domain
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        public string Name { get; set; }
        public string IconPath { get; set; }
        public int? SubCategoryID { get; set; }
    }
}
