using HospitalAppoimentSolution.Data.Models;
using HospitalAppoimentSolution.Services.Infrastructure;

namespace HospitalAppoimentSolution.Services.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {

    }
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
