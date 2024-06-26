using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Bson;

namespace AppControleMantec.Application.Services
{
    public class OrdemDeServicoAppService : IOrdemDeServicoAppService
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoAppService(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository ?? throw new ArgumentNullException(nameof(ordemDeServicoRepository));
        }

        public async Task<IEnumerable<OrdemDeServicoDTO>> GetOrdensDeServicoAsync()
        {
            var ordensDeServico = await _ordemDeServicoRepository.GetOrdensDeServicoAsync();
            var ordensDeServicoDto = new List<OrdemDeServicoDTO>();

            foreach (var os in ordensDeServico)
            {
                ordensDeServicoDto.Add(new OrdemDeServicoDTO
                {
                    Id = os.Id,
                    ClienteID = os.ClienteID,
                    FuncionarioID = os.FuncionarioID,
                    ProdutoID = os.ProdutoID,
                    ServicoID = os.ServicoID,
                    DataEntrada = os.DataEntrada,
                    DataConclusao = os.DataConclusao,
                    Status = os.Status,
                    Observacoes = os.Observacoes,
                    Ativo = os.Ativo
                });
            }

            return ordensDeServicoDto;
        }

        public async Task<OrdemDeServicoDTO> GetOrdemDeServicoByIdAsync(string id)
        {
            var ordemDeServico = await _ordemDeServicoRepository.GetOrdemDeServicoByIdAsync(id);
            if (ordemDeServico == null)
            {
                return null; // Or return appropriate response
            }

            var ordemDeServicoDto = new OrdemDeServicoDTO
            {
                Id = ordemDeServico.Id,
                ClienteID = ordemDeServico.ClienteID,
                FuncionarioID = ordemDeServico.FuncionarioID,
                ProdutoID = ordemDeServico.ProdutoID,
                ServicoID = ordemDeServico.ServicoID,
                DataEntrada = ordemDeServico.DataEntrada,
                DataConclusao = ordemDeServico.DataConclusao,
                Status = ordemDeServico.Status,
                Observacoes = ordemDeServico.Observacoes,
                Ativo = ordemDeServico.Ativo
            };

            return ordemDeServicoDto;
        }

        public async Task<IEnumerable<OrdemDeServicoDTO>> GetOrdensDeServicoAtivasAsync()
        {
            var ordensDeServicoAtivas = await _ordemDeServicoRepository.GetOrdensDeServicoAtivasAsync();
            var ordensDeServicoAtivasDto = new List<OrdemDeServicoDTO>();

            foreach (var os in ordensDeServicoAtivas)
            {
                ordensDeServicoAtivasDto.Add(new OrdemDeServicoDTO
                {
                    Id = os.Id,
                    ClienteID = os.ClienteID,
                    FuncionarioID = os.FuncionarioID,
                    ProdutoID = os.ProdutoID,
                    ServicoID = os.ServicoID,
                    DataEntrada = os.DataEntrada,
                    DataConclusao = os.DataConclusao,
                    Status = os.Status,
                    Observacoes = os.Observacoes,
                    Ativo = os.Ativo
                });
            }

            return ordensDeServicoAtivasDto;
        }

        public async Task<string> InsertOrdemDeServicoAsync(OrdemDeServicoDTO ordemDeServicoDto)
        {
            if (ordemDeServicoDto == null)
            {
                throw new ArgumentNullException(nameof(ordemDeServicoDto));
            }

            var ordemDeServico = new OrdemDeServico
            {
                Id = string.IsNullOrEmpty(ordemDeServicoDto.Id) ? ObjectId.GenerateNewId().ToString() : ordemDeServicoDto.Id,
                ClienteID = ordemDeServicoDto.ClienteID,
                FuncionarioID = ordemDeServicoDto.FuncionarioID,
                ProdutoID = ordemDeServicoDto.ProdutoID,
                ServicoID = ordemDeServicoDto.ServicoID,
                DataEntrada = ordemDeServicoDto.DataEntrada,
                DataConclusao = ordemDeServicoDto.DataConclusao,
                Status = ordemDeServicoDto.Status,
                Observacoes = ordemDeServicoDto.Observacoes,
                Ativo = ordemDeServicoDto.Ativo
            };

            await _ordemDeServicoRepository.InsertOrdemDeServicoAsync(ordemDeServico);

            return ordemDeServico.Id; // Return the generated or provided Id
        }


        public async Task UpdateOrdemDeServicoAsync(OrdemDeServicoDTO ordemDeServicoDto)
        {
            if (ordemDeServicoDto == null)
            {
                throw new ArgumentNullException(nameof(ordemDeServicoDto));
            }

            var ordemDeServico = new OrdemDeServico
            {
                Id = ordemDeServicoDto.Id,
                ClienteID = ordemDeServicoDto.ClienteID,
                FuncionarioID = ordemDeServicoDto.FuncionarioID,
                ProdutoID = ordemDeServicoDto.ProdutoID,
                ServicoID = ordemDeServicoDto.ServicoID,
                DataEntrada = ordemDeServicoDto.DataEntrada,
                DataConclusao = ordemDeServicoDto.DataConclusao,
                Status = ordemDeServicoDto.Status,
                Observacoes = ordemDeServicoDto.Observacoes,
                Ativo = ordemDeServicoDto.Ativo
            };

            await _ordemDeServicoRepository.UpdateOrdemDeServicoAsync(ordemDeServico);
        }

        public async Task DesativarOrdemDeServicoAsync(string id)
        {
            await _ordemDeServicoRepository.DesativarOrdemDeServicoAsync(id);
        }

        public async Task AtivarOrdemDeServicoAsync(string id)
        {
            await _ordemDeServicoRepository.AtivarOrdemDeServicoAsync(id);
        }
    }
}
