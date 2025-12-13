using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Recourse;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface IRecourseService
    {
        Task<IResult> CreateRecourseAsync(CreateRecourseViewModel model, int creatorId);
        Task<IResult> UpdateRecourseAsync(UpdateRecourseViewModel model, int updaterId);
        Task<IResult> DeleteRecourseAsync(int recourseId, int userId);
    }
}
