using MediatR;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppEstoque.Queries
{
    public class EstoqueGetByIdQuery : IRequest<EstoqueDTO>
    {
        public string Id { get; set; }
    }
}
