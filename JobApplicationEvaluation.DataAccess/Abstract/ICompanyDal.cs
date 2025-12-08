using JobApplicationEvaluation.Core.DataAccess;
using JobApplicationEvaluation.Entity.Concrete;

namespace JobApplicationEvaluation.DataAccess.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
    }
}
