using MediatR;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Application.AppProduto.Queries
{
    public class ProdutoGetByIdQuery : IRequest<Produto>
    {
        public string Id { get; set; }
    }
}
