using AutoMapper;
using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Constants;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using JobApplicationEvaluation.ViewModels.RequestViewModel.User;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace JobApplicationEvaluation.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserManager(IMapper mapper, IUserDal userDal, PasswordHasher<User> passwordHasher)
        {
            _mapper = mapper;
            _userDal = userDal;
            _passwordHasher = passwordHasher;
        }

        public async Task<IResult> CreateUserAsync(CreateUserRequestViewModel model)
        {
            try
            {
                var exists = await _userDal.AnyAsync(x => x.Email == model.Email);
                if (exists)
                    return new ErrorResult(UserMessages.UserAlreadyExists, (int)HttpStatusCode.BadRequest);

                var user = _mapper.Map<User>(model);
                user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

                await _userDal.AddAsync(user);
                return new SuccessResult(UserMessages.UserCreated, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Beklenmeyen bir hata oluştu: {ex.Message}",
                    (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IDataResult<UserBaseViewModel>> GetUserByGuidIdAsync(string guid)
        {
            try
            {
                if (!Guid.TryParse(guid, out var parsedGuid))
                {
                    return new ErrorDataResult<UserBaseViewModel>(UserMessages.UserUnexpectedError, (int)HttpStatusCode.BadRequest);
                }

                var user = await _userDal.GetAsync(u => u.Guid == parsedGuid);
                if (user == null)
                {
                    return new ErrorDataResult<UserBaseViewModel>(UserMessages.UserNotFoundError, (int)HttpStatusCode.NotFound);
                }

                var userViewModel = _mapper.Map<UserBaseViewModel>(user);
                return new SuccessDataResult<UserBaseViewModel>(userViewModel, UserMessages.UserSuccessfullyFetched);
            }
            catch (FormatException)
            {
                return new ErrorDataResult<UserBaseViewModel>(UserMessages.UserUnexpectedError, (int)HttpStatusCode.BadRequest);
            }
        }

    }
}
