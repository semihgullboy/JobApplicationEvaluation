namespace JobApplicationEvaluation.Entity.Concrete
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Recourse> Recourses { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
