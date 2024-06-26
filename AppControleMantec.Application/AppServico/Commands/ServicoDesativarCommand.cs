using MediatR;
using System;

namespace AppControleMantec.Application.AppServico.Commands
{
    public class ServicoDesativarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
