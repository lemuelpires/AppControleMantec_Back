using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppCliente.Commands;

namespace AppControleMantec.Application.AppCliente.Handlers
{
    public class ClienteUpdateCommandHandler : IRequestHandler<ClienteUpdateCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUpdateCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(ClienteUpdateCommand request, CancellationToken cancellationToken)
        {
            // Converte o Guid para string
            string clienteId = request.Id.ToString();

            var cliente = await _clienteRepository.GetClienteByIdAsync(clienteId);
            if (cliente == null) return false;

            cliente.Nome = request.Nome;
            cliente.Endereco = request.Endereco;
            cliente.Telefone = request.Telefone;
            cliente.Email = request.Email;
            cliente.DataCadastro = request.DataCadastro;
            cliente.Ativo = request.Ativo;

            await _clienteRepository.UpdateClienteAsync(cliente);
            return true;
        }
    }
}
