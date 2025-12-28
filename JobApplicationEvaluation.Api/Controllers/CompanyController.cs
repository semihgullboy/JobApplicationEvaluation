using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationEvaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService, ITokenService tokenService) : base(tokenService)
        {
            _companyService = companyService;
        }

        //Admin olması ayarlanacak
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCompanyViewModel model)
        {
            var result = await _companyService.CreateCompanyAsync(model);
            return HandleResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CompanyBaseViewModel model)
        {
            var result = await _companyService.UpdateCompanyAsync(model);
            return HandleResult(result);
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCategory(int companyId)
        {
            var result = await _companyService.DeleteCompanyAsync(companyId);
            return HandleResult(result);
        }

        [HttpGet("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = await _companyService.GetAllCompanyAsync();
            return HandleResult(result);
        }

        
        [HttpPost("Filter")]
        [AllowAnonymous]
        public async Task<IActionResult> FilterCompanies([FromQuery] CompanyFilterViewModel filter)
        {
            var result = await _companyService.GetFilteredCompaniesAsync(filter);
            return HandleResult(result);
        }

    }
}
