using MediatR;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppFuncionario.Queries
{
    public class FuncionarioGetByIdQuery : IRequest<FuncionarioDTO>
    {
        public string Id { get; set; }
    }
}
