using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace AppControleMantec.Application.Services
{
    public class ServicoAppService : IServicoAppService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly ILogger<ServicoAppService> _logger;

        public ServicoAppService(IServicoRepository servicoRepository, ILogger<ServicoAppService> logger)
        {
            _servicoRepository = servicoRepository ?? throw new ArgumentNullException(nameof(servicoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ServicoDTO>> GetServicosAsync()
        {
            var servicos = await _servicoRepository.GetServicos();
            var servicoDtos = new List<ServicoDTO>();

            foreach (var servico in servicos)
            {
                if (servico != null) // Corrigido CS8603: Verifica se o servico não é nulo
                {
                    servicoDtos.Add(new ServicoDTO
                    {
                        Id = servico.Id ?? throw new InvalidOperationException("Id do serviço não pode ser nulo"),
                        Nome = servico.Nome,
                        Descricao = servico.Descricao,
                        Preco = servico.Preco,
                        Ativo = servico.Ativo
                    });
                }
            }

            return servicoDtos;
        }

        public async Task<ServicoDTO> GetServicoByIdAsync(string id)
        {
            var servico = await _servicoRepository.GetServicoByIdAsync(id);

            // Verifica se o servico retornado não é nulo
            if (servico != null)
            {
                return new ServicoDTO
                {
                    Id = servico.Id ?? throw new InvalidOperationException("Id do serviço não pode ser nulo"),
                    Nome = servico.Nome,
                    Descricao = servico.Descricao,
                    Preco = servico.Preco,
                    Ativo = servico.Ativo
                };
            }
            else
            {
                // Retorna null se o serviço não foi encontrado
                return null;
            }
        }

        public async Task<string> InsertServicoAsync(ServicoDTO servicoDto)
        {
            if (servicoDto == null)
            {
                throw new ArgumentNullException(nameof(servicoDto));
            }

            if (string.IsNullOrEmpty(servicoDto.Nome))
            {
                throw new ArgumentException("O nome do serviço não pode ser nulo ou vazio.", nameof(servicoDto.Nome));
            }

            var servico = new Servico
            {
                Nome = servicoDto.Nome ?? throw new ArgumentNullException(nameof(servicoDto.Nome)), // Garante que Nome não seja nulo
                Descricao = servicoDto.Descricao,
                Preco = servicoDto.Preco,
                Ativo = servicoDto.Ativo
            };

            await _servicoRepository.InsertServicoAsync(servico);

            return servico.Id;
        }

        public async Task UpdateServicoAsync(ServicoDTO servicoDto)
        {
            if (servicoDto == null)
            {
                throw new ArgumentNullException(nameof(servicoDto));
            }

            if (string.IsNullOrEmpty(servicoDto.Id))
            {
                throw new ArgumentNullException(nameof(servicoDto.Id), "O Id do serviço não pode ser nulo");
            }

            var servico = await _servicoRepository.GetServicoByIdAsync(servicoDto.Id);
            if (servico == null)
            {
                _logger.LogWarning("Serviço não encontrado: {ServicoId}", servicoDto.Id);
                throw new Exception("Serviço não encontrado");
            }

            servico.Nome = servicoDto.Nome ?? throw new ArgumentNullException(nameof(servicoDto.Nome), "O nome do serviço não pode ser nulo");
            servico.Descricao = servicoDto.Descricao;
            servico.Preco = servicoDto.Preco;
            servico.Ativo = servicoDto.Ativo;

            await _servicoRepository.UpdateServicoAsync(servico);
            _logger.LogInformation("Serviço atualizado com sucesso: {ServicoId}", servicoDto.Id);
        }

        public async Task DesativarServicoAsync(string id)
        {
            await _servicoRepository.DesativarServicoAsync(id);
        }

        public async Task AtivarServicoAsync(string id)
        {
            await _servicoRepository.AtivarServicoAsync(id);
        }
    }
}
