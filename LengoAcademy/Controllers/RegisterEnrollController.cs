using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class RegisterEnrollController : Controller
    {
        ICourseRepository courseRepository;
        ISectiontRepository sectiontRepository;
        IAccountRepository accountRepository;

        public RegisterEnrollController(
            ICourseRepository _courseRepository,
            ISectiontRepository _sectiontRepository,
            IAccountRepository _accountRepository)
        {
            courseRepository = _courseRepository;
            sectiontRepository = _sectiontRepository;
            accountRepository = _accountRepository;

        }
        public ActionResult Enroll()
        {
            VmEnroll vm = new VmEnroll();
            vm.LiCourse =  courseRepository.LoadAll();
            return View("Enroll", vm);
        }
        public ActionResult FillSections(int Id)
        {
            List<Section> li = sectiontRepository.LoadSectionByCourseID(Id);
            foreach (Section item in li)
            {
                item.StartDate.ToShortDateString();
            }
            return Json(li);
        }

        public ActionResult Save(VmEnroll signUp)
        {
            List<IdentityRole> liRole = accountRepository.GetRoles();
            signUp.liRoles = liRole;
            signUp.LiCourse =  courseRepository.LoadAll();
            var result =  accountRepository.CreateUser(signUp.signUpDTO);
            signUp.signUpDTO = new SignUpDTO();
            return View("DoneEnroll", signUp);
        }
    }
}
