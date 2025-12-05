using JobApplicationEvaluation.Core.Entities;

namespace JobApplicationEvaluation.Entity.Concrete
{
    public class Recourse : BaseEntity
    {

        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public string Position { get; set; }
        public DateTime AppliedAt { get; set; }

        public int StatusId { get; set; }

        public User User { get; set; }
        public Company Company { get; set; }
        public Status Status { get; set; }
    }

}
