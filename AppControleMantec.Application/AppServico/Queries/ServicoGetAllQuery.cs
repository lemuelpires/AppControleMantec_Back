using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppServico.Queries
{
    public class ServicoGetAllQuery : IRequest<IEnumerable<ServicoDTO>>
    {
    }
}
