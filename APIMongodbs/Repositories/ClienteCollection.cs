using APIMongodbs.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace APIMongodbs.Repositories
{
    public class ClienteCollection : IClienteCollection
    {
        internal MongoBDRepository repository = new MongoBDRepository();
        private IMongoCollection<Cliente> collection;
        public ClienteCollection()
        {
            collection = repository.database.GetCollection<Cliente>("Cliente");
        }
        public async Task DeleteCliente(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(s => s.Id, new ObjectId(id));
            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<Cliente>> GetAllCliente()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task InsertCliente(Cliente cliente)
        {
            await collection.InsertOneAsync(cliente);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            var filter = Builders<Cliente>.Filter.Eq(s => s.Id, cliente.Id);
            await collection.ReplaceOneAsync(filter, cliente);
        }
    }
}
