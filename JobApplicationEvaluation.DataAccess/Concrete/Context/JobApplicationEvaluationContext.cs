using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationEvaluation.DataAccess.Concrete.Context
{
    public class JobApplicationEvaluationContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobApplicationEvaluationContext(DbContextOptions<JobApplicationEvaluationContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
