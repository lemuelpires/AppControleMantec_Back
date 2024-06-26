using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Driver;

namespace AppControleMantec.Infra.Data.Mongo.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClienteRepository(IMongoDatabase database)
        {
            _clientesCollection = database.GetCollection<Cliente>("Clientes");
        }

        public async Task InsertClienteAsync(Cliente cliente)
        {
            await _clientesCollection.InsertOneAsync(cliente);
        }

        public async Task<Cliente> GetClienteByIdAsync(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            return await _clientesCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, cliente.Id);
            await _clientesCollection.ReplaceOneAsync(filter, cliente);
            return cliente;
        }

        public async Task DesativarClienteAsync(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            var update = Builders<Cliente>.Update.Set(c => c.Ativo, false);
            await _clientesCollection.UpdateOneAsync(filter, update);
        }

        public async Task AtivarClienteAsync(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, id);
            var update = Builders<Cliente>.Update.Set(c => c.Ativo, true);
            await _clientesCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clientesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientesAtivosAsync()
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Ativo, true);
            return await _clientesCollection.Find(filter).ToListAsync();
        }
    }
}
