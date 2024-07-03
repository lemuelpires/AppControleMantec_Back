using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppEstoque.Commands;

namespace AppControleMantec.Application.Services
{
    public class EstoqueAppService : IEstoqueAppService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IMapper _mapper;

        public EstoqueAppService(IEstoqueRepository estoqueRepository, IMapper mapper)
        {
            _estoqueRepository = estoqueRepository ?? throw new ArgumentNullException(nameof(estoqueRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<EstoqueDTO>> GetEstoquesAsync()
        {
            var estoques = await _estoqueRepository.GetEstoquesAsync();
            return _mapper.Map<IEnumerable<EstoqueDTO>>(estoques);
        }

        public async Task<EstoqueDTO> GetEstoqueByIdAsync(string id)
        {
            var estoque = await _estoqueRepository.GetEstoqueByIdAsync(id);
            return _mapper.Map<EstoqueDTO>(estoque);
        }

        public async Task<string> CriarEstoqueAsync(EstoqueCreateCommand dto)
        {
            var estoque = _mapper.Map<Estoque>(dto);
            estoque.DataAtualizacao = DateTime.UtcNow;
            estoque.Ativo = true;

            await _estoqueRepository.InsertEstoqueAsync(estoque);

            return estoque.Id; // Retornar o ID do estoque criado
        }

        public async Task AtualizarEstoqueAsync(string id, EstoqueUpdateCommand dto)
        {
            var estoque = await _estoqueRepository.GetEstoqueByIdAsync(id)
                ?? throw new Exception("Estoque não encontrado.");

            _mapper.Map(dto, estoque);

            await _estoqueRepository.UpdateEstoqueAsync(estoque);
        }

        public async Task DesativarEstoqueAsync(string id)
        {
            var estoque = await _estoqueRepository.GetEstoqueByIdAsync(id)
                ?? throw new Exception("Estoque não encontrado.");

            estoque.Ativo = false;

            await _estoqueRepository.UpdateEstoqueAsync(estoque);
        }

        public async Task AtivarEstoqueAsync(string id)
        {
            var estoque = await _estoqueRepository.GetEstoqueByIdAsync(id)
                ?? throw new Exception("Estoque não encontrado.");

            estoque.Ativo = true;

            await _estoqueRepository.UpdateEstoqueAsync(estoque);
        }
    }
}
