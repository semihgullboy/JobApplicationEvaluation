using JobApplicationEvaluation.Core.DataAccess.EntityFramework;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.DataAccess.Concrete.Context;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Company;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Company;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationEvaluation.DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, JobApplicationEvaluationContext>, ICompanyDal
    {
        public EfCompanyDal(JobApplicationEvaluationContext context) : base(context)
        {
        }


        public async Task<PagedResult<CompanyListViewModel>> GetFilteredCompaniesAsync(CompanyFilterViewModel filter)
        {
            var query = _context.Companies
                .AsNoTracking()
                .Include(c => c.Sector)
                .Include(c => c.Reviews)
                .Where(c => c.IsActive);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(c => c.Name.ToLower().Contains(filter.Name.ToLower()));

            if (filter.SectorId.HasValue)
                query = query.Where(c => c.SectorId == filter.SectorId.Value);

            var projected = query.Select(c => new CompanyListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City,
                SectorName = c.Sector.Name,
                AverageRating = c.Reviews.Any(r => r.IsActive) ? c.Reviews.Where(r => r.IsActive).Average(r => r.Rating) : 0,
                ReviewCount = c.Reviews.Count(r => r.IsActive)
            });


            projected = filter.SortBy switch
                {
                    CompanySortBy.Rating => filter.SortDesc? projected.OrderByDescending(c => c.AverageRating): projected.OrderBy(c => c.AverageRating),
                    CompanySortBy.ReviewCount => filter.SortDesc? projected.OrderByDescending(c => c.ReviewCount): projected.OrderBy(c => c.ReviewCount),
                    CompanySortBy.Name => filter.SortDesc? projected.OrderByDescending(c => c.Name): projected.OrderBy(c => c.Name),_ => projected.OrderBy(c => c.Name)
                };

            var totalCount = await projected.CountAsync();

            var items = await projected
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<CompanyListViewModel>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
