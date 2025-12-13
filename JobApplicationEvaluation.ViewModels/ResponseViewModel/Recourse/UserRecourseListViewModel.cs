namespace JobApplicationEvaluation.ViewModels.ResponseViewModel.Recourse
{
    public class UserRecourseListViewModel
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public string Position { get; set; }
        public DateTime AppliedAt { get; set; }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }

}
