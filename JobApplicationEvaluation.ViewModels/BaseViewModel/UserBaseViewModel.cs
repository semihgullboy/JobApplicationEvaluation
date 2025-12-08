namespace JobApplicationEvaluation.ViewModels.BaseViewModel
{
    public class UserBaseViewModel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
