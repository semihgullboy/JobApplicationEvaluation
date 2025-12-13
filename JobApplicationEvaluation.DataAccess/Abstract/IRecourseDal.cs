using JobApplicationEvaluation.Core.DataAccess;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Recourse;

namespace JobApplicationEvaluation.DataAccess.Abstract
{
    public interface IRecourseDal : IEntityRepository<Recourse>
    {
        Task<List<UserRecourseListViewModel>> GetUserRecoursesAsync(int userId);
    }
}
