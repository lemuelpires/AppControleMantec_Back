using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.Interfaces
{
    public interface IOrdemDeServicoAppService
    {
        Task<IEnumerable<OrdemDeServicoDTO>> GetOrdensDeServicoAsync();
        Task<OrdemDeServicoDTO> GetOrdemDeServicoByIdAsync(string id);
        Task<IEnumerable<OrdemDeServicoDTO>> GetOrdensDeServicoAtivasAsync();
        Task<string> InsertOrdemDeServicoAsync(OrdemDeServicoDTO ordemDeServicoDto); // Aqui, o tipo de retorno foi ajustado
        Task UpdateOrdemDeServicoAsync(OrdemDeServicoDTO ordemDeServicoDto);
        Task DesativarOrdemDeServicoAsync(string id);
        Task AtivarOrdemDeServicoAsync(string id);
    }
}
