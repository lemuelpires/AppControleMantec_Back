using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppCliente.Commands;

namespace AppControleMantec.Application.AppCliente.Handlers
{
    public class ClienteCreateCommandHandler : IRequestHandler<ClienteCreateCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCreateCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente
            {
                Nome = request.Nome,
                Endereco = request.Endereco,
                Telefone = request.Telefone,
                Email = request.Email,
                DataCadastro = request.DataCadastro,
                Ativo = request.Ativo
            };

            await _clienteRepository.InsertClienteAsync(cliente);
            return true;
        }
    }
}
