using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationEvaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : BaseController
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService, ITokenService tokenService) : base(tokenService)
        {
            _sectorService = sectorService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllSectors()
        {
            var result = await _sectorService.GetAllSectorsAsync();
            return HandleResult(result);
        }

        [HttpPost("{sectorName}")]
        public async Task<IActionResult> CreateSector(string sectorName)
        {
            var result = await _sectorService.CreateSectorAsync(sectorName);
            return HandleResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSector([FromBody] SectorBaseViewModel model)
        {
            var result = await _sectorService.UpdateSectorAsync(model);
            return HandleResult(result);
        }

        [HttpDelete("{sectorId}")]
        public async Task<IActionResult> DeleteSector(int sectorId)
        {
            var result = await _sectorService.DeleteSectorAsync(sectorId);
            return HandleResult(result);
        }
    }
}
