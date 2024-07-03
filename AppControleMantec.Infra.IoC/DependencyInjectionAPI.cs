using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Application.Mappings;
using AppControleMantec.Application.Services;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Driver;
using AppControleMantec.Infra.Data.Mongo.Repositories;
using AppControleMantec.Infra.Data.Mongo;

namespace AppControleMantec.API.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do MongoDB
            services.AddSingleton<IMongoClient>(sp =>
            {
                var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI") ?? configuration.GetConnectionString("MongoDbConnection");
                return new MongoClient(connectionString);
            });

            services.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;
                return client.GetDatabase(databaseName);
            });

            // Registro dos repositórios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IOrdemDeServicoRepository, OrdemDeServicoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();

            // Registro dos serviços de aplicação
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IEstoqueAppService, EstoqueAppService>();
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();
            services.AddScoped<IOrdemDeServicoAppService, OrdemDeServicoAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IServicoAppService, ServicoAppService>();

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

            // Configuração do MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(DTOToCommandMappingProfile).Assembly)
            );

            return services;
        }
    }
}