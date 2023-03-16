using LengoAcademy.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LengoAcademy.SpecificReposoitory
{
    public interface IContactRepository
    {
        int Insert(ContactDTO contactDTO);
        List<ContactDTO> LoadAll();
        ContactDTO Load(int Id);
        void Update(ContactDTO contactDTO);
        void Delete(int Id);
    }
}
