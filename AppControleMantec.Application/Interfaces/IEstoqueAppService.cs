using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.AppCliente.Commands;
using AppControleMantec.Application.AppEstoque.Commands;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.Interfaces
{
    public interface IEstoqueAppService
    {
        Task<IEnumerable<EstoqueDTO>> GetEstoquesAsync();
        Task<EstoqueDTO> GetEstoqueByIdAsync(string id);
        Task<string> CriarEstoqueAsync(EstoqueCreateCommand dto);
        Task AtualizarEstoqueAsync(string id, EstoqueUpdateCommand dto);
        Task DesativarEstoqueAsync(string id);
        Task AtivarEstoqueAsync(string id);
    }
}
