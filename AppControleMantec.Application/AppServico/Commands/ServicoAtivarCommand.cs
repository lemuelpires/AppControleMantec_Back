using MediatR;
using System;

namespace AppControleMantec.Application.AppServico.Commands
{
    public class ServicoAtivarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
