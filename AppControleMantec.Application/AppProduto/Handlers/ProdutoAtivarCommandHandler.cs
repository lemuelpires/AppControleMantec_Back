using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppProduto.Commands;

namespace AppControleMantec.Application.AppProduto.Handlers
{
    public class ProdutoAtivarCommandHandler : IRequestHandler<ProdutoAtivarCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAtivarCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(ProdutoAtivarCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(request.Id.ToString());
            if (produto == null) return false;

            await _produtoRepository.AtivarProdutoAsync(request.Id.ToString());
            return true;
        }
    }
}
