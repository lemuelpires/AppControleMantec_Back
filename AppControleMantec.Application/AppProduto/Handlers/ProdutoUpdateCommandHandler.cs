using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppProduto.Commands;

namespace AppControleMantec.Application.AppProduto.Handlers
{
    public class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUpdateCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(request.Id.ToString());
            if (produto == null) return false;

            produto.Nome = request.Nome;
            produto.Descricao = request.Descricao;
            produto.Quantidade = request.Quantidade;
            produto.Preco = request.Preco;
            produto.Fornecedor = request.Fornecedor;
            produto.ImagemURL = request.ImagemURL;
            produto.Ativo = request.Ativo;

            await _produtoRepository.UpdateProdutoAsync(produto);
            return true;
        }
    }
}
