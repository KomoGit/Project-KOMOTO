using TestingApplication.Library.Repository;
using TestingApplication.Model;

namespace TestingApplication.Services
{
    public class JobService:BaseService<Job>
    {
        public JobService(MyMongoRepository repository):base(repository)
        {
            
        }
    }
}
