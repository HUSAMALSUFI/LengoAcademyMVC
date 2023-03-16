using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System.Collections.Generic;

namespace LengoAcademy.SpecificReposoitory
{
    public interface ITopicsRepository
    {
       int Insert(TopicsDTO topicsDTO);
       List<TopicsDTO> LoadAll();
       TopicsDTO Load(int Id);
/*        Topics LoadByCourseId(int Id);
*/     List<Topics> MainTopics();
       List<Topics> SubTopics();
       void Update(TopicsDTO topicsDTO);
       void Delete(int Id);
       List<Topics> LoadTopicsByCourseID(int Id);
       List<Topics> MainTopics1(int Id);
    }
}
