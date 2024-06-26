using MediatR;
using System.Collections.Generic;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Application.AppProduto.Queries
{
    public class ProdutoGetAtivosQuery : IRequest<IEnumerable<Produto>>
    {
    }
}
