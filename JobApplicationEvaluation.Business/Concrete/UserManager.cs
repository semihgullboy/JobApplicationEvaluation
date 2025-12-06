using AutoMapper;
using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Constants;
using JobApplicationEvaluation.Core.Result;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.Entity.Concrete;
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

    }
}
