using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppOrdemDeServico.Commands;

namespace AppControleMantec.Application.AppOrdemDeServico.Handlers
{
    public class OrdemDeServicoUpdateCommandHandler : IRequestHandler<OrdemDeServicoUpdateCommand, bool>
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoUpdateCommandHandler(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<bool> Handle(OrdemDeServicoUpdateCommand request, CancellationToken cancellationToken)
        {
            var ordemDeServico = await _ordemDeServicoRepository.GetOrdemDeServicoByIdAsync(request.Id);

            if (ordemDeServico == null)
                return false;

            ordemDeServico.ClienteID = request.ClienteID;
            ordemDeServico.FuncionarioID = request.FuncionarioID;
            ordemDeServico.ProdutoID = request.ProdutoID;
            ordemDeServico.ServicoID = request.ServicoID;
            ordemDeServico.DataEntrada = request.DataEntrada;
            ordemDeServico.DataConclusao = request.DataConclusao;
            ordemDeServico.Status = request.Status;
            ordemDeServico.Observacoes = request.Observacoes;

            await _ordemDeServicoRepository.UpdateOrdemDeServicoAsync(ordemDeServico);
            return true;
        }
    }
}
