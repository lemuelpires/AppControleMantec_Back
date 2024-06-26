using MongoDB.Driver;
using AppControleMantec.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace AppControleMantec.Infra.Data.Mongo.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("meubanco");  // Nome do banco de dados
        }

        public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");
        public IMongoCollection<Estoque> Estoques => _database.GetCollection<Estoque>("Estoques");
        public IMongoCollection<Funcionario> Funcionarios => _database.GetCollection<Funcionario>("Funcionarios");
        public IMongoCollection<OrdemDeServico> OrdensDeServico => _database.GetCollection<OrdemDeServico>("OrdensDeServico");
        public IMongoCollection<Produto> Produtos => _database.GetCollection<Produto>("Produtos");
        public IMongoCollection<Servico> Servicos => _database.GetCollection<Servico>("Servicos");
    }
}
