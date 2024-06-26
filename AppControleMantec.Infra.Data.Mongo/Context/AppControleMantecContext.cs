using AppControleMantec.Domain.Entities;
using MongoDB.Driver;

public class AppControleMantecContext
{
    private readonly IMongoDatabase _database;

    public AppControleMantecContext(string connectionString)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("AppControleMantec");
    }

    public IMongoCollection<Produto> Produtos => _database.GetCollection<Produto>("Produtos");
    public IMongoCollection<Servico> Servicos => _database.GetCollection<Servico>("Servicos");
    public IMongoCollection<OrdemDeServico> OrdensDeServico => _database.GetCollection<OrdemDeServico>("OrdensDeServico");
    public IMongoCollection<Funcionario> Funcionarios => _database.GetCollection<Funcionario>("Funcionarios");
    public IMongoCollection<Estoque> Estoques => _database.GetCollection<Estoque>("Estoques");
    public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");

}

