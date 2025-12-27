using System.Text.Json.Serialization;

namespace JobApplicationEvaluation.ViewModels.RequestViewModel.Company
{
    public class CompanyFilterViewModel
    {
        public string? Name { get; set; }
        public int? SectorId { get; set; }
        public CompanySortBy SortBy { get; set; } = CompanySortBy.Name;
        public bool SortDesc { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 12;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompanySortBy
    {
        Name,
        Rating,
        ReviewCount
    }

}
