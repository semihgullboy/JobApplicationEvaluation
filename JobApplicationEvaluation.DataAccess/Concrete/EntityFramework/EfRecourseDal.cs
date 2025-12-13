using JobApplicationEvaluation.Core.DataAccess.EntityFramework;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.DataAccess.Concrete.Context;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Recourse;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationEvaluation.DataAccess.Concrete.EntityFramework
{
    public class EfRecourseDal : EfEntityRepositoryBase<Recourse, JobApplicationEvaluationContext>, IRecourseDal
    {
        public EfRecourseDal(JobApplicationEvaluationContext context) : base(context)
        {
        }

        public async Task<List<UserRecourseListViewModel>> GetUserRecoursesAsync(int userId)
        {
            var recourses = await _context.Recourses
                .AsNoTracking()
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.AppliedAt)
                .Select(r => new UserRecourseListViewModel
                {
                    Id = r.Id,
                    CompanyId = r.CompanyId,
                    CompanyName = r.Company.Name,
                    Position = r.Position,
                    AppliedAt = r.AppliedAt,
                    StatusId = r.StatusId,
                    StatusName = r.Status.Name
                })
                .ToListAsync();

            return recourses;
        }

    }
}
