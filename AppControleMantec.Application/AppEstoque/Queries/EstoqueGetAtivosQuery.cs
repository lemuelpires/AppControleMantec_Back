using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppEstoque.Queries
{
    public class EstoqueGetAtivosQuery : IRequest<IEnumerable<EstoqueDTO>>
    {
    }
}
