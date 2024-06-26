using MediatR;
using AppControleMantec.Domain.Entities;
using System.Collections.Generic;

namespace AppControleMantec.Application.AppCliente.Queries
{
    public class ClienteGetAtivosQuery : IRequest<IEnumerable<Cliente>>
    {
    }
}
