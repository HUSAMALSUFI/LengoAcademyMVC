using LengoAcademy.Domain;
using System.Collections.Generic;

namespace LengoAcademy.SpecificReposoitory
{
    public interface IPlan_ItemRepositorycs
    {
       int Insert(Plan_ItemDTO planDTO);
       List<Plan_ItemDTO> LoadAll();
       void Delete(int Id);
       void Update(Plan_ItemDTO planDTO);
    }
}
