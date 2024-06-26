using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Domain.Interfaces
{
    public interface IServicoRepository
    {
        Task InsertServicoAsync(Servico servico);
        Task<Servico> GetServicoByIdAsync(string id);
        Task UpdateServicoAsync(Servico servico);
        Task DesativarServicoAsync(string id);
        Task AtivarServicoAsync(string id);
        Task<IEnumerable<Servico>> GetServicos();
        Task<IEnumerable<Servico>> GetServicosAtivosAsync();
    }
}
