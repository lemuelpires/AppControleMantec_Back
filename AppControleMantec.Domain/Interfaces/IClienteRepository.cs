using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task InsertClienteAsync(Cliente cliente);
        Task<Cliente> GetClienteByIdAsync(string id);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task DesativarClienteAsync(string id);
        Task AtivarClienteAsync(string id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<IEnumerable<Cliente>> GetClientesAtivosAsync();
    }
}
