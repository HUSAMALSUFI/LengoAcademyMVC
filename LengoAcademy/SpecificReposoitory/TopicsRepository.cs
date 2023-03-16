using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using LengoAcademy.Context;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class TopicsRepository : ITopicsRepository
    {
        private readonly IGeneric<Topics> generic;
        private readonly LengoAcademyContext context;

        public TopicsRepository(IGeneric<Topics> _generic, LengoAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public int Insert(TopicsDTO topicsDTO)
        {
            var newTopics = new Topics()
            {
                Main = topicsDTO.Main,
                Duration = topicsDTO.Duration,
                SubTopicsID = topicsDTO.SubTopicsID,
                Course_ID = topicsDTO.Course_ID,

            };
            return generic.Insert(newTopics);
        }
        public List<TopicsDTO> LoadAll()
        {
            var topics = new List<TopicsDTO>();
            var alltopic =  generic.LoadAll();
            if (alltopic?.Any() == true)
            {
                foreach (var topic in alltopic)
                {
                    topics.Add(new TopicsDTO()
                    {
                        Id = topic.Id,
                        Main = topic.Main,
                        Duration = topic.Duration,
                        SubTopicsID = topic.SubTopicsID,
                        Course_ID = topic.Course_ID,

                    });
                }
            }
            return topics;
        }
        public TopicsDTO Load(int Id)
        {
            var topics =  generic.Load(Id);
            if (topics != null)
            {
                var topicsDetails = new TopicsDTO()
                {
                    Id = topics.Id,
                    Main = topics.Main,
                    Duration = topics.Duration,
                    SubTopicsID = topics.SubTopicsID,
                    Course_ID = topics.Course_ID,
                };
                return topicsDetails;
            }
            return null;
        }
        /* public Topics LoadByCourseId(int Id)
         {
             return context.topics.Where(e => e.Course_ID == Id).FirstOrDefault();
         }*/
        public void Update(TopicsDTO topicsDTO)
        {
            var newtopics = new Topics()
            {
                Id = topicsDTO.Id,
                Main = topicsDTO.Main,
                Duration = topicsDTO.Duration,
                SubTopicsID = topicsDTO.SubTopicsID,
                Course_ID = topicsDTO.Course_ID,
            };
             generic.Update(newtopics);
        }
        public void Delete(int Id)
        {
             generic.Delete(Id);
        }
        public List<Topics> MainTopics()
        {
            List<Topics> topics = context.topics.Where(p => p.SubTopicsID == null).ToList();
            return topics;
        }
        public List<Topics> SubTopics()
        {
            List<Topics> topics = context.topics.Where(s => s.SubTopicsID != null).ToList();
            return topics;
        }
        public List<Topics> LoadTopicsByCourseID(int Id)
        {
            List<Topics> topics = context.topics.Where(s => s.Course_ID == Id).ToList();
            return topics;
        }
        public List<Topics> MainTopics1(int Id)
        {
            List<Topics> topics = context.topics.Where(p => p.SubTopicsID == null && p.Course_ID == Id).ToList();
            return topics;
        }
    }
}
