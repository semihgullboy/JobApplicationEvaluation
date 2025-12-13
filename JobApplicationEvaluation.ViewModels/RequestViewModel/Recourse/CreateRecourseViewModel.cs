using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace JobApplicationEvaluation.ViewModels.RequestViewModel.Recourse
{
    public class CreateRecourseViewModel
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public string Position { get; set; }
        public DateTime AppliedAt { get; set; }

        public int StatusId { get; set; }
    }
}
