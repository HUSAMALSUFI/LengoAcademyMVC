using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System.Collections.Generic;

namespace LengoAcademy.SpecificReposoitory
{
    public interface ISectiontRepository
    {
        int Insert(SectionDTO sectionDTO);
        List<SectionDTO> LoadAll();
        SectionDTO Load(int Id);
        void Update(SectionDTO sectionDTO1);
        void Delete(int Id);
        List<Section> LoadSectionByCourseID(int Id);
    }
}
