using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppServico.Commands;

namespace AppControleMantec.Application.AppServico.Handlers
{
    public class ServicoDesativarCommandHandler : IRequestHandler<ServicoDesativarCommand, bool>
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoDesativarCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<bool> Handle(ServicoDesativarCommand request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetServicoByIdAsync(request.Id.ToString());
            if (servico == null) return false;

            await _servicoRepository.DesativarServicoAsync(request.Id.ToString());
            return true;
        }
    }
}
