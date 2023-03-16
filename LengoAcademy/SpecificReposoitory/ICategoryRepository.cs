using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System.Collections.Generic;

namespace LengoAcademy.SpecificReposoitory
{
    public interface ICategoryRepository
    {
        int Insert(CategoryDTO ctegoryDTO);
        List<CategoryDTO> LoadAll();
        CategoryDTO Load(int Id);
        List<Category> MainCategory();
        List<Category> SubCategory();
        List<Category> SubCategory1(int Id);
        List<Category> LoadSubCategoryByID(int Id);
        void Update(CategoryDTO categoryDTO);
        void Delete(int Id);
        List<Count_Courses> Count();
    }
}
