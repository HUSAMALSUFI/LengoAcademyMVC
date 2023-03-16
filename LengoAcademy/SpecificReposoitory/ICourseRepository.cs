using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System.Collections.Generic;

namespace LengoAcademy.SpecificReposoitory
{
    public interface ICourseRepository
    {
        int Insert(CourseDTO courseDTO);
        List<CourseDTO> LoadAll();
        CourseDTO Load(int Id);
        void Update(CourseDTO courseDTO);
        void Delete(int Id);
        List<Course> LoadCoursesBySubCategoriesID(int Id);
        List<Course> LoadPlan_ItemByCourse_ID(int Id);
        List<Course> LoadCourses();
        Section LoadCourseSectionByCourseId(int Id);
        List<Course> LoadAllByMainCategoryID(int Id);
    }
}
