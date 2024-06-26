using MediatR;
using System;

namespace AppControleMantec.Application.AppProduto.Commands
{
    public class ProdutoAtivarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
