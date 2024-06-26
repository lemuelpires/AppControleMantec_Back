using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppEstoque.Queries
{
    public class EstoqueGetAllQuery : IRequest<IEnumerable<EstoqueDTO>>
    {
    }
}
