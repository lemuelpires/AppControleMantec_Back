using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppOrdemDeServico.Commands;

namespace AppControleMantec.Application.AppOrdemDeServico.Handlers
{
    public class OrdemDeServicoAtivarCommandHandler : IRequestHandler<OrdemDeServicoAtivarCommand, bool>
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoAtivarCommandHandler(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<bool> Handle(OrdemDeServicoAtivarCommand request, CancellationToken cancellationToken)
        {
            var ordemDeServico = await _ordemDeServicoRepository.GetOrdemDeServicoByIdAsync(request.Id);

            if (ordemDeServico == null)
                return false;

            await _ordemDeServicoRepository.AtivarOrdemDeServicoAsync(request.Id);
            return true;
        }
    }
}
