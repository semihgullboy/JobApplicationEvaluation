using JobApplicationEvaluation.Core.DataAccess.EntityFramework;
using JobApplicationEvaluation.DataAccess.Abstract;
using JobApplicationEvaluation.DataAccess.Concrete.Context;
using JobApplicationEvaluation.Entity.Concrete;

namespace JobApplicationEvaluation.DataAccess.Concrete.EntityFramework
{
    public class EfRecourseDal : EfEntityRepositoryBase<Recourse, JobApplicationEvaluationContext>, IRecourseDal
    {
        public EfRecourseDal(JobApplicationEvaluationContext context) : base(context)
        {
        }
    }
}
