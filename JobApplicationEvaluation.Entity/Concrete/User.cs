using JobApplicationEvaluation.Core.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace JobApplicationEvaluation.Entity.Concrete
{
    public class User : BaseEntity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; } 

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Recourse> Recourses { get; set; }
    }
}
