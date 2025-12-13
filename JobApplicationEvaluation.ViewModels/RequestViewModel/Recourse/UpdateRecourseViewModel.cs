using System.Text.Json.Serialization;

namespace JobApplicationEvaluation.ViewModels.RequestViewModel.Recourse
{
    public class UpdateRecourseViewModel
    {
        public int RecourseId { get; set; }
        public int? CompanyId { get; set; }

        public string? Position { get; set; }
        public DateTime? AppliedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int? StatusId { get; set; }
    }
}
