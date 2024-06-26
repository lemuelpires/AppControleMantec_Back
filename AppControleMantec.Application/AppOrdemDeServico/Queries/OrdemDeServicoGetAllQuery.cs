using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppOrdemDeServico.Queries
{
    public class OrdemDeServicoGetAllQuery : IRequest<IEnumerable<OrdemDeServicoDTO>>
    {
    }
}
