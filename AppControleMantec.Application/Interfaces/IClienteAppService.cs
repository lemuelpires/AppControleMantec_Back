using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.AppCliente.Commands;

namespace AppControleMantec.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAsync();
        Task<IEnumerable<ClienteDTO>> GetClientesPaginadosAsync(int page, int pageSize); // Adicionado método para paginação
        Task<ClienteDTO> GetClienteByIdAsync(string id);
        Task<string> CriarClienteAsync(ClienteCreateCommand dto);
        Task AtualizarClienteAsync(string id, ClienteUpdateCommand dto);
        Task DesativarClienteAsync(string id);
        Task AtivarClienteAsync(string id);
    }
}
