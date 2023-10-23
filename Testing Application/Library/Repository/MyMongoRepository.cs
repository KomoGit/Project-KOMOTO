using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestingApplication.Data;

namespace TestingApplication.Library.Repository
{
    public class MyMongoRepository
    {
        public IMongoDatabase mongoDatabase;

        public MyMongoRepository(IOptions<ApplicationDbSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);

            mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
        }
    }
}
