using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task InsertFuncionarioAsync(Funcionario funcionario);
        Task<Funcionario> GetFuncionarioByIdAsync(string id);
        Task UpdateFuncionarioAsync(Funcionario funcionario);
        Task DesativarFuncionarioAsync(string id);
        Task AtivarFuncionarioAsync(string id);
        Task<IEnumerable<Funcionario>> GetFuncionariosAsync();
        Task<IEnumerable<Funcionario>> GetFuncionariosAtivosAsync();
    }
}
