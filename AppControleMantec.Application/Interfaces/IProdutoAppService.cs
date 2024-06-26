using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.Interfaces
{
    public interface IProdutoAppService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutosAsync();
        Task<ProdutoDTO> GetProdutoByIdAsync(string id);
        Task<string> InsertProdutoAsync(ProdutoDTO produtoDto); // Retorna o ID do produto criado
        Task UpdateProdutoAsync(ProdutoDTO produtoDto);
        Task DesativarProdutoAsync(string id);
        Task AtivarProdutoAsync(string id);
    }
}
