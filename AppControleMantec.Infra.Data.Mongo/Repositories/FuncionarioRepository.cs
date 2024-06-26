using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Driver;

namespace AppControleMantec.Infra.Data.Mongo.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IMongoCollection<Funcionario> _funcionariosCollection;

        public FuncionarioRepository(IMongoDatabase database)
        {
            _funcionariosCollection = database.GetCollection<Funcionario>("Funcionarios");
        }

        public async Task InsertFuncionarioAsync(Funcionario funcionario)
        {
            await _funcionariosCollection.InsertOneAsync(funcionario);
        }

        public async Task<Funcionario> GetFuncionarioByIdAsync(string id)
        {
            var filter = Builders<Funcionario>.Filter.Eq(f => f.Id, id);
            return await _funcionariosCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateFuncionarioAsync(Funcionario funcionario)
        {
            var filter = Builders<Funcionario>.Filter.Eq(f => f.Id, funcionario.Id);
            await _funcionariosCollection.ReplaceOneAsync(filter, funcionario);
        }

        public async Task DesativarFuncionarioAsync(string id)
        {
            var filter = Builders<Funcionario>.Filter.Eq(f => f.Id, id);
            var update = Builders<Funcionario>.Update.Set(f => f.Ativo, false);
            await _funcionariosCollection.UpdateOneAsync(filter, update);
        }

        public async Task AtivarFuncionarioAsync(string id)
        {
            var filter = Builders<Funcionario>.Filter.Eq(f => f.Id, id);
            var update = Builders<Funcionario>.Update.Set(f => f.Ativo, true);
            await _funcionariosCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionariosAsync()
        {
            return await _funcionariosCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionariosAtivosAsync()
        {
            var filter = Builders<Funcionario>.Filter.Eq(f => f.Ativo, true);
            return await _funcionariosCollection.Find(filter).ToListAsync();
        }
    }
}
