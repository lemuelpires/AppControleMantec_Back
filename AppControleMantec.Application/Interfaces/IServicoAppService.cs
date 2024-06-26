using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.Interfaces
{
    public interface IServicoAppService
    {
        Task<IEnumerable<ServicoDTO>> GetServicosAsync();
        Task<ServicoDTO> GetServicoByIdAsync(string id);
        Task<string> InsertServicoAsync(ServicoDTO servicoDto);
        Task UpdateServicoAsync(ServicoDTO servicoDto);
        Task DesativarServicoAsync(string id);
        Task AtivarServicoAsync(string id);
    }
}
