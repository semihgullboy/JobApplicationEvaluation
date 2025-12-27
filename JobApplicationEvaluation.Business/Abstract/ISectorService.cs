using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.ViewModels.BaseViewModel;

namespace JobApplicationEvaluation.Business.Abstract
{
    public interface ISectorService
    {
        Task<IResult> CreateSectorAsync(string sectorName);
        Task<IResult> DeleteSectorAsync(int sectorId);
        Task<IResult> UpdateSectorAsync(SectorBaseViewModel viewModel);
        Task<IDataResult<List<SectorBaseViewModel>>> GetAllSectorsAsync();
    }
}
