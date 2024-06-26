﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppEstoque.Commands;

namespace AppControleMantec.Application.AppEstoque.Handlers
{
    public class EstoqueDesativarCommandHandler : IRequestHandler<EstoqueDesativarCommand, bool>
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueDesativarCommandHandler(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<bool> Handle(EstoqueDesativarCommand request, CancellationToken cancellationToken)
        {
            var estoque = await _estoqueRepository.GetEstoqueByIdAsync(request.Id.ToString());
            if (estoque == null) return false;

            await _estoqueRepository.DesativarEstoqueAsync(request.Id.ToString());
            return true;
        }
    }
}
