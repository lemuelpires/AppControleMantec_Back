using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppEstoque.Commands;

namespace AppControleMantec.Application.AppEstoque.Handlers
{
    public class EstoqueUpdateCommandHandler : IRequestHandler<EstoqueUpdateCommand, bool>
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueUpdateCommandHandler(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<bool> Handle(EstoqueUpdateCommand request, CancellationToken cancellationToken)
        {
            var estoque = await _estoqueRepository.GetEstoqueByIdAsync(request.Id.ToString());
            if (estoque == null) return false;

            estoque.ProdutoID = request.ProdutoID;
            estoque.Quantidade = request.Quantidade;
            estoque.DataAtualizacao = DateTime.UtcNow;
            estoque.Ativo = request.Ativo;

            await _estoqueRepository.UpdateEstoqueAsync(estoque);
            return true;
        }
    }
}
