using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.DataAccess.Concrete.Context;
using JobApplicationEvaluation.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobApplicationEvaluation.DataAccess.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobApplicationEvaluationContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Context")));

            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<ICompanyDal, EfCompanyDal>();
            services.AddScoped<IRecourseDal, EfRecourseDal>();
        }
    }
}
