using MediatR;
using System;

namespace AppControleMantec.Application.AppFuncionario.Commands
{
    public class FuncionarioDesativarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
