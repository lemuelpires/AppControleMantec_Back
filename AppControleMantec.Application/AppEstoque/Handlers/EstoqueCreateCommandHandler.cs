using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppEstoque.Commands;

namespace AppControleMantec.Application.AppEstoque.Handlers
{
    public class EstoqueCreateCommandHandler : IRequestHandler<EstoqueCreateCommand, bool>
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueCreateCommandHandler(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<bool> Handle(EstoqueCreateCommand request, CancellationToken cancellationToken)
        {
            var estoque = new Estoque
            {
                ProdutoID = request.ProdutoID,
                Quantidade = request.Quantidade,
                DataAtualizacao = DateTime.UtcNow,
                Ativo = true
            };

            await _estoqueRepository.InsertEstoqueAsync(estoque);
            return true;
        }
    }
}
