using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppControleMantec.Infra.Data.Mongo.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly IMongoCollection<Servico> _servicoCollection;
        private readonly ILogger<ServicoRepository> _logger;

        public ServicoRepository(IMongoDatabase database, ILogger<ServicoRepository> logger)
        {
            _servicoCollection = database.GetCollection<Servico>("Servicos");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InsertServicoAsync(Servico servico)
        {
            await _servicoCollection.InsertOneAsync(servico);
        }

        public async Task<Servico> GetServicoByIdAsync(string id)
        {
            try
            {
                var objectId = new ObjectId(id);
                var filter = Builders<Servico>.Filter.Eq("_id", objectId);
                return await _servicoCollection.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar serviço por Id: {ex.Message}");
                throw;
            }
        }


        public async Task UpdateServicoAsync(Servico servico)
        {
            var filter = Builders<Servico>.Filter.Eq(p => p.Id, servico.Id);
            await _servicoCollection.ReplaceOneAsync(filter, servico);
        }

        public async Task DesativarServicoAsync(string id)
        {
            try
            {
                var objectId = new ObjectId(id);
                var update = Builders<Servico>.Update.Set("Ativo", false);
                var filter = Builders<Servico>.Filter.Eq("_id", objectId);
                await _servicoCollection.UpdateOneAsync(filter, update);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao desativar serviço: {ex.Message}");
                throw;
            }
        }

        public async Task AtivarServicoAsync(string id)
        {
            try
            {
                var objectId = new ObjectId(id);
                var update = Builders<Servico>.Update.Set("Ativo", true);
                var filter = Builders<Servico>.Filter.Eq("_id", objectId);
                await _servicoCollection.UpdateOneAsync(filter, update);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao ativar serviço: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Servico>> GetServicos()
        {
            try
            {
                return await _servicoCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar todos os serviços: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Servico>> GetServicosAtivosAsync()
        {
            try
            {
                var filter = Builders<Servico>.Filter.Eq("Ativo", true);
                return await _servicoCollection.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar serviços ativos: {ex.Message}");
                throw;
            }
        }
    }
}
