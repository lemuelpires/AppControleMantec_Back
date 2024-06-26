using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.AppOrdemDeServico.Commands;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Application.AppOrdemDeServico.Handlers
{
    public class OrdemDeServicoCreateCommandHandler : IRequestHandler<OrdemDeServicoCreateCommand, bool>
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoCreateCommandHandler(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<bool> Handle(OrdemDeServicoCreateCommand request, CancellationToken cancellationToken)
        {
            var ordemDeServico = new OrdemDeServico
            {
                ClienteID = request.ClienteID,
                FuncionarioID = request.FuncionarioID,
                ProdutoID = request.ProdutoID,
                ServicoID = request.ServicoID,
                DataEntrada = request.DataEntrada,
                DataConclusao = request.DataConclusao,
                Status = request.Status,
                Observacoes = request.Observacoes,
                Ativo = true // Por padrão, a ordem de serviço é criada como ativa
            };

            await _ordemDeServicoRepository.InsertOrdemDeServicoAsync(ordemDeServico);
            return true;
        }
    }
}
