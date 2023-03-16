using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IGeneric<Plan> generic;

        public PlanRepository(IGeneric<Plan> _generic)
        {
            generic = _generic;
        }

        public int Insert(PlanDTO planDTO)
        {
            var newPlan = new Plan()
            {
                Name = planDTO.Name,
            };
            return generic.Insert(newPlan);
        }
        public List<PlanDTO> LoadAll()
        {
            var Plans = new List<PlanDTO>();
            var allPlans =  generic.LoadAll();
            if (allPlans?.Any() == true)
            {
                foreach (var Plan in allPlans)
                {
                    Plans.Add(new PlanDTO()
                    {
                        Id = Plan.Id,
                        Name = Plan.Name,
                    });
                }
            }
            return Plans;
        }
        public PlanDTO Load(int Id)
        {
            var Plans =  generic.Load(Id);
            if (Plans != null)
            {
                var plansDetails = new PlanDTO()
                {
                    Name = Plans.Name,
                };
                return plansDetails;
            }
            return null;
        }
        public void Update(PlanDTO planDTO)
        {
            var newPlans = new Plan()
            {
                Id = planDTO.Id,
                Name = planDTO.Name,
            };
             generic.Update(newPlans);
        }
        public void Delete(int Id)
        {
            generic.Delete(Id);
        }
    }
}