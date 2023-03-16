using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class CourseDetailsController : Controller
    {

        ICourseRepository courseRepository;
        ITopicsRepository topicsRepository;
        ISectiontRepository sectiontRepository;
        IProcessRepository processRepository;

        public CourseDetailsController
            (ICourseRepository _courseRepository,
            ITopicsRepository _topicsRepository,
            ISectiontRepository _sectiontRepository,
            IProcessRepository _processRepository)
        {
            courseRepository = _courseRepository;
            topicsRepository = _topicsRepository;
            sectiontRepository = _sectiontRepository;
            processRepository = _processRepository;
        }
        public  ActionResult Course_Details(int Id)
        {
            VmCourse_Details vm = new VmCourse_Details();
            vm.course = courseRepository.Load(Id);
            vm.liMainTopics = topicsRepository.MainTopics1(Id);
            vm.liSubTopics = topicsRepository.LoadTopicsByCourseID(Id);
            vm.LiSection = sectiontRepository.LoadSectionByCourseID(Id);
            vm.LiProcess = processRepository.LoadProcessByCourseID(Id);
            vm.licourses = courseRepository.LoadPlan_ItemByCourse_ID(Id);
            vm.section = courseRepository.LoadCourseSectionByCourseId(Id);
            return View("Course_Details", vm);
        }
    }
}
