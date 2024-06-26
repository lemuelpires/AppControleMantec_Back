using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppOrdemDeServico.Queries
{
    public class OrdemDeServicoGetAtivasQuery : IRequest<IEnumerable<OrdemDeServicoDTO>>
    {
    }
}
