using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Company;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Company;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface ICompanyService
    {
        Task<IResult> CreateCompanyAsync(CreateCompanyViewModel model);
        Task<IResult> UpdateCompanyAsync(CompanyBaseViewModel model);
        Task<IResult> DeleteCompanyAsync(int companyId);
        Task<IDataResult<List<CompanyBaseViewModel>>> GetAllCompanyAsync();
        Task<IDataResult<PagedResult<CompanyListViewModel>>> GetFilteredCompaniesAsync(CompanyFilterViewModel filter);
    }
}
