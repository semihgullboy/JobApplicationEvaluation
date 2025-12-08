using JobApplicationEvaluation.Core.DataAccess.EntityFramework;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.DataAccess.Concrete.Context;
using JobApplicationEvaluation.Entity.Concrete;

namespace JobApplicationEvaluation.DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, JobApplicationEvaluationContext>, ICompanyDal
    {
        public EfCompanyDal(JobApplicationEvaluationContext context) : base(context)
        {
        }
    }
}
