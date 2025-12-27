using JobApplicationEvaluation.Core.DataAccess;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Company;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Company;

namespace JobApplicationEvaluation.DataAccess.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
        Task<PagedResult<CompanyListViewModel>> GetFilteredCompaniesAsync(CompanyFilterViewModel filter);
    }
}
