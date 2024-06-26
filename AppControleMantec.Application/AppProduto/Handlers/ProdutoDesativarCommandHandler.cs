using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppProduto.Commands;

namespace AppControleMantec.Application.AppProduto.Handlers
{
    public class ProdutoDesativarCommandHandler : IRequestHandler<ProdutoDesativarCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDesativarCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(ProdutoDesativarCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(request.Id.ToString());
            if (produto == null) return false;

            await _produtoRepository.DesativarProdutoAsync(request.Id.ToString());
            return true;
        }
    }
}
