using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using LengoAcademy.Context;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly IGeneric<Process> generic;
        private readonly LengoAcademyContext context;

        public ProcessRepository(IGeneric<Process> _generic, LengoAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public int Insert(ProcessDTO processDTO)
        {
            var newProcess = new Process()
            {
                Title = processDTO.Title,
                Descrption = processDTO.Descrption,
                Course_ID = processDTO.Course_ID,
            };
            return generic.Insert(newProcess);
        }
        public List<ProcessDTO> LoadAll()
        {
            var process = new List<ProcessDTO>();
            var allprocess = generic.LoadAll();
            if (allprocess?.Any() == true)
            {
                foreach (var process1 in allprocess)
                {
                    process.Add(new ProcessDTO()
                    {
                        Id = process1.Id,
                        Title = process1.Title,
                        Descrption = process1.Descrption,
                        Course_ID = process1.Course_ID
                    });
                }
            }
            return process;
        }
        public ProcessDTO Load(int Id)
        {
            var process = generic.Load(Id);
            if (process != null)
            {
                var processDetails = new ProcessDTO()
                {
                    Id = process.Id,
                    Title = process.Title,
                    Descrption = process.Descrption,
                    Course_ID = process.Course_ID,
                };
                return processDetails;
            }
            return null;
        }

        /*
               public Process Load(int Id)
               {
                   return context.Process.Where(e => e.Course_ID == Id).FirstOrDefault();
               }*/
        public void Update(ProcessDTO processDTO)
        {
            var newprocess = new Process()
            {
                Id = processDTO.Id,
                Title = processDTO.Title,
                Descrption = processDTO.Descrption,
                Course_ID = processDTO.Course_ID,
            };
            generic.Update(newprocess);
        }
        public void Delete(int Id)
        {
            generic.Delete(Id);
        }

        public List<Process> LoadProcessByCourseID(int Id)
        {
            List<Process> processes = context.Process.Where(s => s.Course_ID == Id).ToList();
            return processes;
        }
    }
}
