using JobApplicationEvaluation.Core.Entities;

namespace JobApplicationEvaluation.Entity.Concrete
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int StatusId { get; set; }

        public User User { get; set; }
        public Company Company { get; set; }
        public Status Status { get; set; }
    }

}
