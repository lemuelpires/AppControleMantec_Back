using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Driver;

namespace AppControleMantec.Infra.Data.Mongo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMongoCollection<Produto> _produtosCollection;

        public ProdutoRepository(IMongoDatabase database)
        {
            _produtosCollection = database.GetCollection<Produto>("Produtos");
        }

        public async Task InsertProdutoAsync(Produto produto)
        {
            await _produtosCollection.InsertOneAsync(produto);
        }

        public async Task<Produto> GetProdutoByIdAsync(string id)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            return await _produtosCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, produto.Id);
            await _produtosCollection.ReplaceOneAsync(filter, produto);
        }

        public async Task DesativarProdutoAsync(string id)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            var update = Builders<Produto>.Update.Set(p => p.Ativo, false);
            await _produtosCollection.UpdateOneAsync(filter, update);
        }

        public async Task AtivarProdutoAsync(string id)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, id);
            var update = Builders<Produto>.Update.Set(p => p.Ativo, true);
            await _produtosCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _produtosCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosAtivosAsync()
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Ativo, true);
            return await _produtosCollection.Find(filter).ToListAsync();
        }
    }
}
