using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppServico.Commands;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Application.AppServico.Handlers
{
    public class ServicoCreateCommandHandler : IRequestHandler<ServicoCreateCommand, bool>
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoCreateCommandHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<bool> Handle(ServicoCreateCommand request, CancellationToken cancellationToken)
        {
            var servico = new Servico
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco,
                Ativo = request.Ativo
            };

            await _servicoRepository.InsertServicoAsync(servico);
            return true;
        }
    }
}
