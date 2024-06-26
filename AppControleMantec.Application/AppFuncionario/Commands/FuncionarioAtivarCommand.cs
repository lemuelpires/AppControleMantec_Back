using MediatR;
using System;

namespace AppControleMantec.Application.AppFuncionario.Commands
{
    public class FuncionarioAtivarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
