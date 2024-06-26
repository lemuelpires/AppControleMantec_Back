using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppFuncionario.Commands;

namespace AppControleMantec.Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncionarioDTO>> GetFuncionariosAsync()
        {
            var funcionarios = await _funcionarioRepository.GetFuncionariosAsync();
            return _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
        }

        public async Task<FuncionarioDTO> GetFuncionarioByIdAsync(string id)
        {
            var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(id);
            return _mapper.Map<FuncionarioDTO>(funcionario);
        }

        public async Task<string> CriarFuncionarioAsync(FuncionarioCreateCommand dto)
        {
            var funcionario = _mapper.Map<Funcionario>(dto);
            funcionario.Ativo = true;

            await _funcionarioRepository.InsertFuncionarioAsync(funcionario);

            return funcionario.Id; // Retornar o ID do funcionário criado
        }

        public async Task AtualizarFuncionarioAsync(string id, FuncionarioUpdateCommand dto)
        {
            var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(id);

            if (funcionario == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }

            _mapper.Map(dto, funcionario);

            await _funcionarioRepository.UpdateFuncionarioAsync(funcionario);
        }

        public async Task DesativarFuncionarioAsync(string id)
        {
            var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(id);

            if (funcionario == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }

            funcionario.Ativo = false;

            await _funcionarioRepository.UpdateFuncionarioAsync(funcionario);
        }

        public async Task AtivarFuncionarioAsync(string id)
        {
            var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(id);

            if (funcionario == null)
            {
                throw new Exception("Funcionário não encontrado.");
            }

            funcionario.Ativo = true;

            await _funcionarioRepository.UpdateFuncionarioAsync(funcionario);
        }
    }
}
