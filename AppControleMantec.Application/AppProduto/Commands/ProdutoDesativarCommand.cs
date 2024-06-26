using MediatR;
using System;

namespace AppControleMantec.Application.AppProduto.Commands
{
    public class ProdutoDesativarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
