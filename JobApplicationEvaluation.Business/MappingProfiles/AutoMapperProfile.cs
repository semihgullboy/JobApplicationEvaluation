using AutoMapper;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using JobApplicationEvaluation.ViewModels.RequestViewModel.User;

namespace JobApplicationEvaluation.Business.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserRequestViewModel, User>();
            CreateMap<User, UserBaseViewModel>();
        }
    }
}
