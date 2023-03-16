using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using LengoAcademy.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LengoAcademy.SpecificReposoitory
{
    public class SectiontRepository : ISectiontRepository
    {
        private readonly IGeneric<Section> generic;
        private readonly LengoAcademyContext context;

        public SectiontRepository(IGeneric<Section> _generic, LengoAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public int Insert(SectionDTO sectionDTO)
        {
            var newSection = new Section()
            {
                StartDate = sectionDTO.StartDate,
                EndDate = sectionDTO.EndDate,
                Type = sectionDTO.Type,
                Time = sectionDTO.Time,
                Capacity = sectionDTO.Capacity,
                Course_ID = sectionDTO.Course_ID,
                LiCourse_Schedule = new List<Course_Schedule>()
            };
            foreach (Course_ScheduleDTO item in sectionDTO.LiCourse_Schedule) {

                Course_Schedule dayInfo = new Course_Schedule();
                dayInfo.Day = item.Day;
                newSection.LiCourse_Schedule.Add(dayInfo);
            }
            return generic.Insert(newSection);
        }
        public List<SectionDTO> LoadAll()
        {
            var section = new List<SectionDTO>();
            var allsection =  generic.LoadAll();
            if (allsection?.Any() == true)
            {
                foreach (var section1 in allsection)
                {
                    section.Add(new SectionDTO()
                    {
                        Id = section1.Id,
                        StartDate = section1.StartDate,
                        EndDate = section1.EndDate,
                        Type = section1.Type,
                        Time = section1.Time,
                        Capacity = section1.Capacity,
                        Course_ID = section1.Course_ID,
                        LiCourse_Schedule = new List<Course_ScheduleDTO>()
                    });
                   /* foreach (Course_Schedule item in section1.LiCourse_Schedule)
                    {

                        Course_ScheduleDTO dayInfo = new Course_ScheduleDTO();
                        dayInfo.Day = item.Day;
                        section.LiCourse_Schedule.Add(dayInfo);
                    }*/
                }
            }
            return section;
        }
        public SectionDTO Load(int Id)
        {
            var section =  generic.Load(Id);
            if (section != null)
            {
                var sectionDetails = new SectionDTO()
                {
                    Id = section.Id,
                    StartDate = section.StartDate,
                    EndDate = section.EndDate,
                    Type = section.Type,
                    Time = section.Time,
                    Capacity = section.Capacity,
                    Course_ID = section.Course_ID,
                };
                return sectionDetails;
            }
            return null;
        }
      
        public void Update(SectionDTO sectionDTO)
        {
            var newSection = new Section()
            {
                Id = sectionDTO.Id,
                StartDate = sectionDTO.StartDate,
                EndDate = sectionDTO.EndDate,
                Type = sectionDTO.Type,
                Time = sectionDTO.Time,
                Capacity = sectionDTO.Capacity,
                Course_ID = sectionDTO.Course_ID,
                LiCourse_Schedule = new List<Course_Schedule>()
            };
            foreach (Course_ScheduleDTO item in sectionDTO.LiCourse_Schedule)
            {

                Course_Schedule dayInfo = new Course_Schedule();
                dayInfo.Day = item.Day;
                newSection.LiCourse_Schedule.Add(dayInfo);
            }
             generic.Update(newSection);
        }

        public void Delete(int Id)
        {
            generic.Delete(Id);
        }
        public List<Section> LoadSectionByCourseID(int Id)
        {
            List<Section> section = context.sections.Where(s => s.Course_ID == Id).ToList();
            
            foreach (Section item in section)
            {
                item.LiCourse_Schedule = new List<Course_Schedule>();
                item.LiCourse_Schedule=context.course_Schedule.Where(s => s.Section_ID == item.Id).ToList();
            }

            return section;
        }
    }
}
