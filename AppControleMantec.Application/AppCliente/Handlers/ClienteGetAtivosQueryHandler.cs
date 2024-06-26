using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppCliente.Queries;

namespace AppControleMantec.Application.AppCliente.Handlers
{
    public class ClienteGetAtivosQueryHandler : IRequestHandler<ClienteGetAtivosQuery, IEnumerable<Cliente>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteGetAtivosQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> Handle(ClienteGetAtivosQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetClientesAtivosAsync();
        }
    }
}
