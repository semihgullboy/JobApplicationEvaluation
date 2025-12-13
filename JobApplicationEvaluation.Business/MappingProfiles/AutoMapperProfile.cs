using AutoMapper;
using JobApplicationEvaluation.Entity.Concrete;
using JobApplicationEvaluation.ViewModels.BaseViewModel;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Company;
using JobApplicationEvaluation.ViewModels.RequestViewModel.Recourse;
using JobApplicationEvaluation.ViewModels.RequestViewModel.User;
using JobApplicationEvaluation.ViewModels.ResponseViewModel.Recourse;

namespace JobApplicationEvaluation.Business.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserRequestViewModel, User>();
            CreateMap<User, UserBaseViewModel>();
            CreateMap<CreateCompanyViewModel, Company>();
            CreateMap<Company, CompanyBaseViewModel>();
            CreateMap<CreateRecourseViewModel, Recourse>();
            CreateMap<UpdateRecourseViewModel, Recourse>();
            CreateMap<Recourse, UserRecourseListViewModel>();
        }
    }
}
