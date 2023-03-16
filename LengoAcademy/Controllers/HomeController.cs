using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        ICategoryRepository categoryRepository;
        ICourseRepository courseRepository;
        ISectiontRepository sectiontRepository;

        public HomeController(ICategoryRepository _categoryRepository,
            ICourseRepository _courseRepository,
            ISectiontRepository _sectiontRepository
)
        {
            categoryRepository = _categoryRepository;
            courseRepository = _courseRepository;
            sectiontRepository = _sectiontRepository;

        }
        public ActionResult Index()
        {
            VmHome vm = new VmHome();
            vm.LiCategory = categoryRepository.MainCategory();
            vm.LiCourse = courseRepository.LoadCourses();
            /*            vm.section = sectiontRepository.LoadSectionByCourseID(Id);
            */
            return View("Index", vm);
        }
    }
}

