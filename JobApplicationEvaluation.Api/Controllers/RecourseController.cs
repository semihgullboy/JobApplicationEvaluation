using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Recourse;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationEvaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecourseController : BaseController
    {
        private readonly IRecourseService _recourseService;

        public RecourseController(IRecourseService recourseService, ITokenService tokenService) : base(tokenService)
        {
            _recourseService = recourseService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRecourse([FromBody] CreateRecourseViewModel model)
        {
            var result = await _recourseService.CreateRecourseAsync(model, userModel.Id);
            return HandleResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRecourse([FromBody] UpdateRecourseViewModel model)
        {
            var result = await _recourseService.UpdateRecourseAsync(model, userModel.Id);
            return HandleResult(result);
        }

        [HttpDelete("delete/{recourseId}")]
        public async Task<IActionResult> DeleteRecourse(int recourseId)
        {
            var result = await _recourseService.DeleteRecourseAsync(recourseId, userModel.Id);
            return HandleResult(result);
        }
    }
}
