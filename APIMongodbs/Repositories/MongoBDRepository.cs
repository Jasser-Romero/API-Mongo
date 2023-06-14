
using MongoDB.Driver;

namespace APIMongodbs.Repositories
{
    public class MongoBDRepository
    {
        public MongoClient client;
        public IMongoDatabase database;

        public MongoBDRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("MiEmpresa");

        }
    }
}
