using Microsoft.Extensions.DependencyInjection;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Infra.Persistence.Repositories;
using AppControleMantec.Infra.Persistence.Contexts;
using AppControleMantec.Infrastructure.Repositories;
using System;

namespace AppControleMantec.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registro dos repositórios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IOrdemDeServicoRepository, OrdemDeServicoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();

            // Registro do contexto do banco de dados
            services.AddScoped<AppDbContext>(); // Exemplo de contexto fictício

            // Outros serviços de infraestrutura, se houver
        }
    }
}
