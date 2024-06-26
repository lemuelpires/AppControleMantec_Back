using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppServico.Commands;

namespace AppControleMantec.Application.AppServico.Handlers
{
    public class ServicoUpdateCommandHandler : IRequestHandler<ServicoUpdateCommand, bool>
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoUpdateCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<bool> Handle(ServicoUpdateCommand request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetServicoByIdAsync(request.Id.ToString());
            if (servico == null) return false;

            servico.Nome = request.Nome;
            servico.Descricao = request.Descricao;
            servico.Preco = request.Preco;
            servico.Ativo = request.Ativo;

            await _servicoRepository.UpdateServicoAsync(servico);
            return true;
        }
    }
}
