using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppCliente.Commands;

namespace AppControleMantec.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesPaginadosAsync(int page, int pageSize)
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes.Skip((page - 1) * pageSize).Take(pageSize));
        }

        public async Task<ClienteDTO> GetClienteByIdAsync(string id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<string> CriarClienteAsync(ClienteCreateCommand dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);
            if (cliente == null)
            {
                throw new InvalidOperationException("Falha ao mapear Cliente.");
            }

            cliente.DataCadastro = DateTime.UtcNow;
            cliente.Ativo = true;

            await _clienteRepository.InsertClienteAsync(cliente);

            if (cliente.Id == null)
            {
                throw new InvalidOperationException("ID do cliente não foi gerado corretamente.");
            }

            return cliente.Id; // Retornar o ID do cliente criado
        }

        public async Task AtualizarClienteAsync(string id, ClienteUpdateCommand dto)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }

            _mapper.Map(dto, cliente); // Linha provável do aviso CS8603

            await _clienteRepository.UpdateClienteAsync(cliente);
        }

        public async Task DesativarClienteAsync(string id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }

            cliente.Ativo = false;

            await _clienteRepository.UpdateClienteAsync(cliente);
        }

        public async Task AtivarClienteAsync(string id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }

            cliente.Ativo = true;

            await _clienteRepository.UpdateClienteAsync(cliente);
        }
    }
}
