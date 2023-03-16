using LengoAcademy.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using LengoAcademy.Entity;

namespace LengoAcademy.SpecificReposoitory
{
    public interface IProcessRepository
    {
        int Insert(ProcessDTO processDTO);
        List<ProcessDTO> LoadAll();
        /*        Task<ProcessDTO> Load(int Id);
        */
        void Update(ProcessDTO processDTO);
        void Delete(int Id);
        List<Process> LoadProcessByCourseID(int Id);
    }
}
