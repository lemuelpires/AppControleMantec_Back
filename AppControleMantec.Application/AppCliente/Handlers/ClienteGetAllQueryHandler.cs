using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppCliente.Queries;

namespace AppControleMantec.Application.AppCliente.Handlers
{
    public class ClienteGetAllQueryHandler : IRequestHandler<ClienteGetAllQuery, IEnumerable<Cliente>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteGetAllQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> Handle(ClienteGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetClientesAsync();
        }
    }
}
