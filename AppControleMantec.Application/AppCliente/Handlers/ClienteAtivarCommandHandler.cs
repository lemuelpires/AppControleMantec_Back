using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppCliente.Commands;

namespace AppControleMantec.Application.AppCliente.Handlers
{
    public class ClienteAtivarCommandHandler : IRequestHandler<ClienteAtivarCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAtivarCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(ClienteAtivarCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(request.Id.ToString());
            if (cliente == null) return false;

            await _clienteRepository.AtivarClienteAsync(request.Id.ToString());
            return true;
        }
    }
}
