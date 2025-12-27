namespace JobApplicationEvaluation.ViewModels.ResponseViewModel.Company
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }

    public class CompanyListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string SectorName { get; set; }
        public double AverageRating { get; set; }
        public int ReviewCount { get; set; }
    }
}
