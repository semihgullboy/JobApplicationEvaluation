using AutoMapper;
using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Constants;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Company;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Company;
using System.Net;

namespace JobApplicationEvaluation.Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;
        private readonly IMapper _mapper;

        public CompanyManager(ICompanyDal companyDal, IMapper mapper)
        {
            _companyDal = companyDal;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IResult> CreateCompanyAsync(CreateCompanyViewModel model)
        {
            try
            {
                var company = _mapper.Map<Company>(model);
                await _companyDal.AddAsync(company);
                return new SuccessResult(CompanyMessages.CompanyCreated, (int)HttpStatusCode.Created);

            }
            catch (Exception)
            {
                return new ErrorResult(CompanyMessages.CompanyCreationError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> UpdateCompanyAsync(CompanyBaseViewModel model)
        {
            try
            {
                var updatedCompany = new Company
                {
                    Id = model.Id,
                    Name = model.Name,
                    UpdatedAt = DateTime.UtcNow
                };
                await _companyDal.UpdateSinglePropAsync(updatedCompany, x => x.Name, x => x.UpdatedAt);
                return new SuccessResult(CompanyMessages.CompanyUpdated, (int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new ErrorResult(CompanyMessages.CompanyUpdateError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeleteCompanyAsync(int companyId)
        {
            try
            {
                var company = await _companyDal.GetAsync(c => c.Id == companyId);
                if (company == null)
                {
                    return new ErrorResult(CompanyMessages.CompanyNotFound, (int)HttpStatusCode.NotFound);
                }
                await _companyDal.DeleteAsync(company);
                return new SuccessResult(CompanyMessages.CompanyDeleted, (int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new ErrorResult(CompanyMessages.CompanyDeletionError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<List<CompanyBaseViewModel>>> GetAllCompanyAsync()
        {
            try
            {
                var companies = await _companyDal.GetAllAsync(c => c.IsActive);
                if (!companies.Any())
                {
                    return new ErrorDataResult<List<CompanyBaseViewModel>>(CompanyMessages.CompanyNotFound, (int)HttpStatusCode.NotFound);
                }
                var companyBaseViewModels = _mapper.Map<List<CompanyBaseViewModel>>(companies);
                return new SuccessDataResult<List<CompanyBaseViewModel>>(companyBaseViewModels, CompanyMessages.CompanyListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<CompanyBaseViewModel>>(CompanyMessages.CompanyListingError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<PagedResult<CompanyListViewModel>>> GetFilteredCompaniesAsync(CompanyFilterViewModel filter)
        {
            try
            {
                var pagedResult = await _companyDal.GetFilteredCompaniesAsync(filter);
                return new SuccessDataResult<PagedResult<CompanyListViewModel>>(pagedResult, CompanyMessages.CompanyListed);
            }
            catch (Exception)
            {
                return new ErrorDataResult<PagedResult<CompanyListViewModel>>(CompanyMessages.CompanyListingError, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
