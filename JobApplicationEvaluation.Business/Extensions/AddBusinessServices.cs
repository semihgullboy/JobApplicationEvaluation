using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Concrete;
using JobApplicationEvaluation.Business.MappingProfiles;
using JobApplicationEvaluation.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobApplicationEvaluation.Business.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenManager>();
            services.AddScoped<IAuthenticationService, AuthenticationManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<PasswordHasher<User>>();

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
