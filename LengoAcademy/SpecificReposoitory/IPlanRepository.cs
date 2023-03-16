using LengoAcademy.Domain;
using System.Collections.Generic;

namespace LengoAcademy.SpecificReposoitory
{
    public interface IPlanRepository
    {
        int Insert(PlanDTO planDTO);
        List<PlanDTO> LoadAll();
        PlanDTO Load(int Id);
       void Update(PlanDTO planDTO);
       void Delete(int Id);
    }
}
