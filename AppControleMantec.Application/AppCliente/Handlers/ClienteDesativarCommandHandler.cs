using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppCliente.Commands;

namespace AppControleMantec.Application.AppCliente.Handlers
{
    public class ClienteDesativarCommandHandler : IRequestHandler<ClienteDesativarCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDesativarCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(ClienteDesativarCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(request.Id.ToString());
            if (cliente == null) return false;

            await _clienteRepository.DesativarClienteAsync(request.Id.ToString());
            return true;
        }
    }
}
