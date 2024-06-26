using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AppControleMantec.Application;
using AppControleMantec.Application.AppCliente.Commands;
using AppControleMantec.Application.AppCliente.Queries;
using AppControleMantec.Application.AppEstoque.Commands;
using AppControleMantec.Application.AppEstoque.Queries;
using AppControleMantec.Application.AppFuncionario.Commands;
using AppControleMantec.Application.AppFuncionario.Queries;
using AppControleMantec.Application.AppOrdemDeServico.Commands;
using AppControleMantec.Application.AppOrdemDeServico.Queries;
using AppControleMantec.Application.AppProduto.Commands;
using AppControleMantec.Application.AppProduto.Queries;
using AppControleMantec.Application.AppServico.Commands;
using AppControleMantec.Application.AppServico.Queries;
using AppControleMantec.Application.AppCliente.Handlers;
using AppControleMantec.Application.AppEstoque.Handlers;
using AppControleMantec.Application.AppFuncionario.Handlers;
using AppControleMantec.Application.AppOrdemDeServico.Handlers;
using AppControleMantec.Application.AppProduto.Handlers;
using AppControleMantec.Application.AppServico.Handlers;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.API.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registro dos handlers e queries da aplicação
            services.AddMediatR(typeof(Startup).Assembly);

            services.AddTransient<IRequestHandler<ClienteCreateCommand, bool>, ClienteCreateCommandHandler>();
            services.AddTransient<IRequestHandler<ClienteUpdateCommand, bool>, ClienteUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<ClienteDesativarCommand, bool>, ClienteDesativarCommandHandler>();
            services.AddTransient<IRequestHandler<ClienteAtivarCommand, bool>, ClienteAtivarCommandHandler>();
            services.AddTransient<IRequestHandler<ClienteGetAllQuery, IEnumerable<ClienteDTO>>, ClienteGetAllQueryHandler>();
            services.AddTransient<IRequestHandler<ClienteGetByIdQuery, ClienteDTO>, ClienteGetByIdQueryHandler>();

            services.AddTransient<IRequestHandler<EstoqueCreateCommand, bool>, EstoqueCreateCommandHandler>();
            services.AddTransient<IRequestHandler<EstoqueUpdateCommand, bool>, EstoqueUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<EstoqueDesativarCommand, bool>, EstoqueDesativarCommandHandler>();
            services.AddTransient<IRequestHandler<EstoqueAtivarCommand, bool>, EstoqueAtivarCommandHandler>();
            services.AddTransient<IRequestHandler<EstoqueGetAllQuery, IEnumerable<EstoqueDTO>>, EstoqueGetAllQueryHandler>();
            services.AddTransient<IRequestHandler<EstoqueGetByIdQuery, EstoqueDTO>, EstoqueGetByIdQueryHandler>();

            services.AddTransient<IRequestHandler<FuncionarioCreateCommand, bool>, FuncionarioCreateCommandHandler>();
            services.AddTransient<IRequestHandler<FuncionarioUpdateCommand, bool>, FuncionarioUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<FuncionarioDesativarCommand, bool>, FuncionarioDesativarCommandHandler>();
            services.AddTransient<IRequestHandler<FuncionarioAtivarCommand, bool>, FuncionarioAtivarCommandHandler>();
            services.AddTransient<IRequestHandler<FuncionarioGetAllQuery, IEnumerable<FuncionarioDTO>>, FuncionarioGetAllQueryHandler>();
            services.AddTransient<IRequestHandler<FuncionarioGetByIdQuery, FuncionarioDTO>, FuncionarioGetByIdQueryHandler>();

            services.AddTransient<IRequestHandler<OrdemDeServicoCreateCommand, bool>, OrdemDeServicoCreateCommandHandler>();
            services.AddTransient<IRequestHandler<OrdemDeServicoUpdateCommand, bool>, OrdemDeServicoUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<OrdemDeServicoCancelarCommand, bool>, OrdemDeServicoCancelarCommandHandler>();
            services.AddTransient<IRequestHandler<OrdemDeServicoAtivarCommand, bool>, OrdemDeServicoAtivarCommandHandler>();
            services.AddTransient<IRequestHandler<OrdemDeServicoGetAllQuery, IEnumerable<OrdemDeServicoDTO>>, OrdemDeServicoGetAllQueryHandler>();
            services.AddTransient<IRequestHandler<OrdemDeServicoGetByIdQuery, OrdemDeServicoDTO>, OrdemDeServicoGetByIdQueryHandler>();

            services.AddTransient<IRequestHandler<ProdutoCreateCommand, bool>, ProdutoCreateCommandHandler>();
            services.AddTransient<IRequestHandler<ProdutoUpdateCommand, bool>, ProdutoUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<ProdutoDesativarCommand, bool>, ProdutoDesativarCommandHandler>();
            services.AddTransient<IRequestHandler<ProdutoAtivarCommand, bool>, ProdutoAtivarCommandHandler>();
            services.AddTransient<IRequestHandler<ProdutoGetAllQuery, IEnumerable<ProdutoDTO>>, ProdutoGetAllQueryHandler>();
            services.AddTransient<IRequestHandler<ProdutoGetByIdQuery, ProdutoDTO>, ProdutoGetByIdQueryHandler>();

            services.AddTransient<IRequestHandler<ServicoCreateCommand, bool>, ServicoCreateCommandHandler>();
            services.AddTransient<IRequestHandler<ServicoUpdateCommand, bool>, ServicoUpdateCommandHandler>();
            services.AddTransient<IRequestHandler<ServicoDesativarCommand, bool>, ServicoDesativarCommandHandler>();
            services.AddTransient<IRequestHandler<ServicoAtivarCommand, bool>, ServicoAtivarCommandHandler>();
            services.AddTransient<IRequestHandler<ServicoGetAllQuery, IEnumerable<ServicoDTO>>, ServicoGetAllQueryHandler>();
            services.AddTransient<IRequestHandler<ServicoGetByIdQuery, ServicoDTO>, ServicoGetByIdQueryHandler>();

            // Outros serviços da API, se houver
        }
    }
}
