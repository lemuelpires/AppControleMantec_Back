using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(string id);
        Task InsertProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(Produto produto);
        Task DesativarProdutoAsync(string id);
        Task AtivarProdutoAsync(string id);
    }
}
