using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class ContactUsController : Controller
    {
        IContactRepository ContactRepository;
        public ContactUsController(IContactRepository _ContactRepository)
        {
            ContactRepository = _ContactRepository;
        }
        public ActionResult Contact_Us()
        {
            VmContact vm = new VmContact();
            vm.Contact = ContactRepository.LoadAll();
            return View("Contact_Us", vm);
        }
    }
}
