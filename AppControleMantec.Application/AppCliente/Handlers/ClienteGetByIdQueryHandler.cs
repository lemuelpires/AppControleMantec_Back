using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppCliente.Queries;

namespace AppControleMantec.Application.AppCliente.Handlers
{
    public class ClienteGetByIdQueryHandler : IRequestHandler<ClienteGetByIdQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteGetByIdQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Handle(ClienteGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetClienteByIdAsync(request.Id.ToString());
        }
    }
}
