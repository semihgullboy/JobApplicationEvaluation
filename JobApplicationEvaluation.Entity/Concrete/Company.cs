using JobApplicationEvaluation.Core.Entities;

namespace JobApplicationEvaluation.Entity.Concrete
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Recourse> Recourses { get; set; }
    }
}
