using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Domain.Interfaces
{
    public interface IEstoqueRepository
    {
        Task InsertEstoqueAsync(Estoque estoque);
        Task<Estoque> GetEstoqueByIdAsync(string id);
        Task UpdateEstoqueAsync(Estoque estoque);
        Task DesativarEstoqueAsync(string id);
        Task AtivarEstoqueAsync(string id);
        Task<IEnumerable<Estoque>> GetEstoquesAsync(); // Método para obter todos os estoques
        Task<IEnumerable<Estoque>> GetEstoquesAtivosAsync();
    }
}
