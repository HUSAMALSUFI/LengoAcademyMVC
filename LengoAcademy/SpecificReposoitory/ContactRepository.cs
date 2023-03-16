using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LengoAcademy.Generic;
using LengoAcademy.Domain;
using LengoAcademy.Entity;

namespace LengoAcademy.SpecificReposoitory
{
    public class ContactRepository : IContactRepository
    {
        private readonly IGeneric<Contact> generic;

        public ContactRepository(IGeneric<Contact> _generic)
        {
            generic = _generic;
        }
        public int Insert(ContactDTO contactDTO)
        {
            var newContact = new Contact()
            {
                Email = contactDTO.Email,
                Address = contactDTO.Address,
                Phone = contactDTO.Phone,
                LogoPath=contactDTO.LogoPath,
                FavIconPath=contactDTO.FavIconPath,
            };
            return generic.Insert(newContact);
        }
        public List<ContactDTO> LoadAll()
        {
            var contacts = new List<ContactDTO>();
            var allcontact = generic.LoadAll();
            if (allcontact?.Any() == true)
            {
                foreach (var contact in allcontact)
                {
                    contacts.Add(new ContactDTO()
                    {
                        Id = contact.Id,
                        Email = contact.Email,
                        Address = contact.Address,
                        Phone = contact.Phone,
                        LogoPath=contact.LogoPath,
                        FavIconPath=contact.FavIconPath,
                    });
                }
            }
            return contacts;
        }
        public ContactDTO Load(int Id)
        {
            var contacts =  generic.Load(Id);
            if (contacts != null)
            {
                var contactsDetails = new ContactDTO()
                {
                    Email = contacts.Email,
                    Address = contacts.Address,
                    Phone = contacts.Phone,
                    LogoPath = contacts.LogoPath,
                    FavIconPath = contacts.FavIconPath,
                };
                return contactsDetails;
            }
            return null;
        }
        public void Update(ContactDTO contactDTO)
        {
            var newContact = new Contact()
            {
                Id = contactDTO.Id,
                Email = contactDTO.Email,
                Address = contactDTO.Address,
                Phone = contactDTO.Phone,
                LogoPath = contactDTO.LogoPath,
                FavIconPath = contactDTO.FavIconPath,
            };
             generic.Update(newContact);
        }
        public void Delete(int Id)
        {
            generic.Delete(Id);
        }
    }
}