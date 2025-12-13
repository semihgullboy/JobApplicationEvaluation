using AutoMapper;
using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Constants;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Recourse;
using System.Net;

namespace JobApplicationEvaluation.Business.Concrete
{
    public class RecourseManager : IRecourseService
    {
        private readonly IRecourseDal _recourseDal;
        private readonly IMapper _mapper;

        public RecourseManager(IRecourseDal recourseDal, IMapper mapper)
        {
            _recourseDal = recourseDal;
            _mapper = mapper;
        }

        public async Task<IResult> CreateRecourseAsync(CreateRecourseViewModel model, int creatorId)
        {
            try
            {
                model.UserId = creatorId;
                var recourse = _mapper.Map<Recourse>(model);
                await _recourseDal.AddAsync(recourse);
                return new SuccessResult(RecourseMessages.RecourseCreated, (int)HttpStatusCode.Created);

            }
            catch (Exception)
            {
                return new ErrorResult(RecourseMessages.RecourseCreationError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> UpdateRecourseAsync(UpdateRecourseViewModel model, int updaterId)
        {
            try
            {
                var existingRecourse = await _recourseDal.GetAsync(r => r.Id == model.RecourseId);
                if (existingRecourse == null)
                {
                    return new ErrorResult(RecourseMessages.RecourseNotFound, (int)HttpStatusCode.NotFound);
                }
                if (existingRecourse.UserId != updaterId)
                {
                    return new ErrorResult(RecourseMessages.UnauthorizedUpdate, (int)HttpStatusCode.Forbidden);
                }

                _mapper.Map(model, existingRecourse);
                await _recourseDal.UpdateAsync(existingRecourse);

                return new SuccessResult(RecourseMessages.RecourseUpdated, (int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new ErrorResult(RecourseMessages.RecourseUpdateError, (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IResult> DeleteRecourseAsync(int recourseId, int userId)
        {
            try
            {
                var existingRecourse = await _recourseDal.GetAsync(r => r.Id == recourseId);
                if (existingRecourse == null)
                {
                    return new ErrorResult(RecourseMessages.RecourseNotFound, (int)HttpStatusCode.NotFound);
                }
                if (existingRecourse.UserId != userId)
                {
                    return new ErrorResult(RecourseMessages.UnauthorizedDelete, (int)HttpStatusCode.Forbidden);
                }

                await _recourseDal.DeleteAsync(existingRecourse);
                return new SuccessResult(RecourseMessages.RecourseDeleted, (int)HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new ErrorResult(RecourseMessages.RecourseDeleteError, (int)HttpStatusCode.InternalServerError);
            }
        }


    }
}
