using LengoAcademy.Domain;
using System.Collections.Generic;

namespace LengoAcademy.SpecificReposoitory
{
    public interface ICourse_ScheduleRepository
    {
        int Insert(Course_ScheduleDTO course_ScheduleDTO);
        List<Course_ScheduleDTO> LoadAll();
        Course_ScheduleDTO Load(int Id);
        void Update(Course_ScheduleDTO course_ScheduleDTO);
        void Delete(int Id);
    }
}
