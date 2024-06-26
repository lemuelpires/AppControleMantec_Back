using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppProduto.Commands;

namespace AppControleMantec.Application.AppProduto.Handlers
{
    public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoCreateCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Quantidade = request.Quantidade,
                Preco = request.Preco,
                Fornecedor = request.Fornecedor,
                DataEntrada = request.DataEntrada,
                ImagemURL = request.ImagemURL,
                Ativo = request.Ativo
            };

            await _produtoRepository.InsertProdutoAsync(produto);
            return true;
        }
    }
}
