using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.AppFuncionario.Commands;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.Interfaces
{
    public interface IFuncionarioAppService
    {
        Task<IEnumerable<FuncionarioDTO>> GetFuncionariosAsync();
        Task<FuncionarioDTO> GetFuncionarioByIdAsync(string id);
        Task<string> CriarFuncionarioAsync(FuncionarioCreateCommand dto);
        Task AtualizarFuncionarioAsync(string id, FuncionarioUpdateCommand dto);
        Task DesativarFuncionarioAsync(string id);
        Task AtivarFuncionarioAsync(string id);
    }
}
