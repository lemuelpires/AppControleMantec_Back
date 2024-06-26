using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Driver;

namespace AppControleMantec.Infra.Data.Mongo.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly IMongoCollection<Estoque> _estoquesCollection;

        public EstoqueRepository(IMongoDatabase database)
        {
            _estoquesCollection = database.GetCollection<Estoque>("Estoques");
        }

        public async Task InsertEstoqueAsync(Estoque estoque)
        {
            await _estoquesCollection.InsertOneAsync(estoque);
        }

        public async Task<Estoque> GetEstoqueByIdAsync(string id)
        {
            var filter = Builders<Estoque>.Filter.Eq(e => e.Id, id);
            return await _estoquesCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateEstoqueAsync(Estoque estoque)
        {
            var filter = Builders<Estoque>.Filter.Eq(e => e.Id, estoque.Id);
            await _estoquesCollection.ReplaceOneAsync(filter, estoque);
        }

        public async Task DesativarEstoqueAsync(string id)
        {
            var filter = Builders<Estoque>.Filter.Eq(e => e.Id, id);
            var update = Builders<Estoque>.Update.Set(e => e.Ativo, false);
            await _estoquesCollection.UpdateOneAsync(filter, update);
        }

        public async Task AtivarEstoqueAsync(string id)
        {
            var filter = Builders<Estoque>.Filter.Eq(e => e.Id, id);
            var update = Builders<Estoque>.Update.Set(e => e.Ativo, true);
            await _estoquesCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Estoque>> GetEstoquesAsync()
        {
            return await _estoquesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Estoque>> GetEstoquesAtivosAsync()
        {
            var filter = Builders<Estoque>.Filter.Eq(e => e.Ativo, true);
            return await _estoquesCollection.Find(filter).ToListAsync();
        }
    }
}
