using TestingApplication.Library.Repository;
using TestingApplication.Model;

namespace TestingApplication.Services
{
    public class CompanyService : BaseService<Company>
    {
        public CompanyService(MyMongoRepository repository) : base(repository) { }
    }
}
