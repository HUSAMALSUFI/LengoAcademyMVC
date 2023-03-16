using LengoAcademy.Generic;
using LengoAcademy.Context;
using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGeneric<Category> generic;
        private readonly LengoAcademyContext context;

        public CategoryRepository(IGeneric<Category> _generic, LengoAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public int Insert(CategoryDTO categoryDTO)
        {
            var newCategory = new Category()
            {
                Name = categoryDTO.Name,
                IconPath = categoryDTO.IconPath,
                SubCategoryID = categoryDTO.SubCategoryID
            };
            return generic.Insert(newCategory);
        }
        public  List<CategoryDTO> LoadAll()
        {
            var categories = new List<CategoryDTO>();
            var allcategory =  context.categories.ToList();
            if (allcategory?.Any() == true)
            {
                foreach (var category in allcategory)
                {
                    categories.Add(new CategoryDTO()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IconPath = category.IconPath,
                        SubCategoryID = category.SubCategoryID
                    });
                }
            }
            return categories;
        }
        public CategoryDTO Load(int Id)
        {
            var category = generic.Load(Id);
            if (category != null)
            {
                var categoryDetails = new CategoryDTO()
                {
                    Name = category.Name,
                    IconPath = category.IconPath,
                    SubCategoryID = category.SubCategoryID
                };
                return categoryDetails;
            }
            return null;
        }
        public void Update(CategoryDTO categoryDTO)
        {
            var newCategory = new Category()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                IconPath = categoryDTO.IconPath,
                SubCategoryID = categoryDTO.SubCategoryID
            };
            generic.Update(newCategory);
        }
        public void Delete(int Id)
        {
            generic.Delete(Id);
        }
        public List<Category> MainCategory()
        {
            List<Category> category = context.categories.Where(p => p.SubCategoryID == null).ToList();
            foreach (Category item in category)
            {
                item.LiCourse = new List<Course>();
                List<Category> liSub= context.categories.Where(c => c.SubCategoryID == item.Id).ToList();
                foreach (Category liSubItem in liSub)
                {
                    item.LiCourse.AddRange( context.courses.Where(c => c.SubCategoriesID == liSubItem.Id).ToList());
                }

            }
            return category;
        }
        public List<Category> LoadSubCategoryByID(int Id)
        {
            List<Category> category = context.categories.Where(s => s.SubCategoryID == Id).ToList();
            return category;
        }
        public List<Category> SubCategory()
        {
            List<Category> category = context.categories.Where(s => s.SubCategoryID != null).ToList();
            return category;
        }

        public List<Category> SubCategory1(int Id)
        {
            Category x =context.categories.Where(c=>c.Id== Id).FirstOrDefault();
            List<Category> licategory = context.categories.Where(s => s.SubCategoryID == x.SubCategoryID).ToList();
            return licategory;
        }

        public List<Count_Courses> Count()
        {
            List<Count_Courses> li = context.categories.Select(data =>
            new Count_Courses()
            {
                category = data,
                Count = data.LiCourse.Count()
            }
            ).ToList();
            return li;
        }
    }
}
