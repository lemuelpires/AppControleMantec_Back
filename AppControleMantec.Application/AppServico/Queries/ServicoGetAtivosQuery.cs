using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppServico.Queries
{
    public class ServicoGetAtivosQuery : IRequest<IEnumerable<ServicoDTO>>
    {
    }
}
