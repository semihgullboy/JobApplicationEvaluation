using AutoMapper;
using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Constants;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using System.Net;

namespace JobApplicationEvaluation.Business.Concrete
{
    public class SectorManager : ISectorService
    {
        private readonly ISectorDal _sectorDaL;
        private readonly IMapper _mapper;

        public SectorManager(ISectorDal sectorDaL, IMapper mapper)
        {
            _sectorDaL = sectorDaL;
            _mapper = mapper;
        }

        public async Task<IResult> CreateSectorAsync(string sectorName)
        {
            try
            {
                var sector = new Sector { Name = sectorName};
                await _sectorDaL.AddAsync(sector);
                return new SuccessResult(SectorMessages.SectorCreated, (int)HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new ErrorResult(SectorMessages.SectorCreationError, (int)HttpStatusCode.InternalServerError);
            }
        }


        public async Task<IResult> DeleteSectorAsync(int sectorId)
        {
            try
            {
                var sector = await _sectorDaL.GetAsync(s => s.Id == sectorId);
                if (sector == null)
                {
                    return new ErrorResult(SectorMessages.SectorNotFound, (int)HttpStatusCode.NotFound);
                }
                await _sectorDaL.DeleteAsync(sector);
                return new SuccessResult(SectorMessages.SectorDeleted, (int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new ErrorResult(SectorMessages.SectorDeleteError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<List<SectorBaseViewModel>>> GetAllSectorsAsync()
        {
            try
            {
                var sectors = await _sectorDaL.GetAllAsync(s => s.IsActive);
                if (!sectors.Any())
                {
                    return new ErrorDataResult<List<SectorBaseViewModel>>(SectorMessages.SectorNotFound, (int)HttpStatusCode.NotFound);
                }
                var sectorViewModels = _mapper.Map<List<SectorBaseViewModel>>(sectors);
                return new SuccessDataResult<List<SectorBaseViewModel>>(sectorViewModels, SectorMessages.SectorsFetched);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<SectorBaseViewModel>>(SectorMessages.SectorsFetchError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> UpdateSectorAsync(SectorBaseViewModel viewModel)
        {
            try
            {
                var updatedSector = new Sector
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    UpdatedAt = DateTime.UtcNow
                };
                await _sectorDaL.UpdateSinglePropAsync(updatedSector, x => x.Name, x => x.UpdatedAt);
                return new SuccessResult(SectorMessages.SectorUpdated, (int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new ErrorResult(SectorMessages.SectorUpdateError, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
