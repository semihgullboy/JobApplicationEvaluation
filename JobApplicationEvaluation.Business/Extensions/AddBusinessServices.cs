using JobApplicationEvaluation.Business.Abstract;
using JobApplicationEvaluation.Business.Concrete;
using JobApplicationEvaluation.Business.MappingProfiles;
using JobApplicationEvaluation.Entity.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IRecourseService, RecourseManager>();
            services.AddScoped<ISectorService, SectorManager>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = true,
                     ValidateIssuer = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidAudience = configuration["JWTAuth:ValidAudienceURL"],
                     ValidIssuer = configuration["JWTAuth:ValidIssuerURL"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTAuth:SecretKey"])),

                     LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                     {
                         return expires != null ? expires > DateTime.UtcNow : false;
                     },
                 };
             });
        }
    }
}
